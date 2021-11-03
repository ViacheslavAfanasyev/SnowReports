using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnowReports.Models;
using System.Linq;

namespace SnowReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnowReportsController : ControllerBase
    {
        ISnowReportsRepository SnowRepository;

        public SnowReportsController(ISnowReportsRepository snowRepository)
        {
            this.SnowRepository = snowRepository;
        }

        [HttpGet]
        public IEnumerable<DailyData> Get()
        {
            var results = new List<DailyData>();
            //results.Add(new DailyData(DateTime.Now, 15));
            return results;
        }

        [HttpGet("GetRangedDate")]
        public List<HourData> GetRangedDate(DateTime startDate, DateTime endDate, AssignmentGroup assigmentGroup, int timeZoneOffsetInHours = 0)
        {
            int deltaHours = 200;

            var chagnes = this.SnowRepository.GetAllCaseStateChanges(startDate, endDate, assigmentGroup, deltaHours);
            var hourData = new List<HourData>();

            for(DateTime i = startDate; i<=endDate;i=i.AddHours(1))
            {

                var hourTicketStates = new Dictionary<TicketState, int>();
                hourTicketStates.Add(TicketState.New, 0);
                hourTicketStates.Add(TicketState.In_Progress, 0);
                hourTicketStates.Add(TicketState.Awaiting_Customer, 0);
                hourTicketStates.Add(TicketState.Awaiting_Problem, 0);
                hourTicketStates.Add(TicketState.Awaiting_Change, 0);

                foreach (var item in chagnes)
                {
                    var ticketState = item.GetStateForDateTime(i);


                    switch (ticketState)
                    {
                        case TicketState.New:
                            hourTicketStates[TicketState.New] += 1;break;
                        case TicketState.In_Progress:
                            hourTicketStates[TicketState.In_Progress] += 1; break;
                        case TicketState.Awaiting_Customer:
                            hourTicketStates[TicketState.Awaiting_Customer] += 1; break;
                        case TicketState.Awaiting_Problem:
                            hourTicketStates[TicketState.Awaiting_Problem] += 1; break;
                        case TicketState.Awaiting_Change:
                            hourTicketStates[TicketState.Awaiting_Change] += 1; break;
                        case TicketState.DefaultValue:
                            break;
                    }

                }

                hourData.Add(new HourData(i.AddHours(timeZoneOffsetInHours), hourTicketStates));



            }


            return hourData;
            //return GenerateFakeDate(startDate, endDate, state);
        }

        List<DailyData> GenerateFakeDate(DateTime startDate, DateTime endDate, TicketState state)
        {
            var results = new List<DailyData>();
                        
            int i = 0;

            while (true)
            {
                var newDate = startDate.AddDays(i);
                if (newDate.Date <= endDate.Date)
                {
                    var random = new Random().Next(0, 1000);
                    var dictionary = new Dictionary<TicketState, int>();
                    dictionary.Add(state, random);

                    var random1 = new Random().Next(0, 100);
                    var random2 = new Random().Next(0, 1000);
                    dictionary.Add(TicketState.In_Progress, random1);
                    dictionary.Add(TicketState.New, random2);

                    results.Add(new DailyData(newDate, dictionary));
                    i++;
                }
                else
                {
                    break;
                }
            }

            return results;
        }



    }
}
