using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnowReports.Models;
using System.Linq;
using DataAccess.Extensions;

namespace SnowReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnowReportsController : ControllerBase
    {
        ISnowReportsRepository SnowRepository;
        private readonly IConfiguration Config;

        public SnowReportsController(ISnowReportsRepository snowRepository, IConfiguration config)
        {
            this.SnowRepository = snowRepository;
            this.Config = config;
        }



        [HttpGet("States")]
        public IEnumerable<string> States()
        {
            return this.SnowRepository.GetCaseStates();
        }

        [HttpGet("AccumulatedAssignmentGroups")]
        public IEnumerable<string> AccumulatedAssignmentGroups()
        {
            return this.SnowRepository.GetTechSupportAssignmentGroups(this.Config.GetValue<string>("Assignment_group_v3"), true);

        }

        [HttpGet("AssignmentGroups")]
        public IEnumerable<string> AssignmentGroups()
        {
            return this.SnowRepository.GetTechSupportAssignmentGroups(this.Config.GetValue<string>("Assignment_group_v3"), false);

        }

        [HttpGet("TicketsLevels")]
        public IEnumerable<string> TicketsLevels()
        {
            return typeof(TicketLevels).EnumToList();
            //return this.Config.GetValue<string>("TicketsLevels").Split(',');
        }

        //[HttpGet("GetRangedDate1")]
        //public List<HourData> GetRangedDate1(DateTime startDate, DateTime endDate, AssignmentGroup assigmentGroup, int timeZoneOffsetInHours = 0)
        //{
        //    int deltaHours = 200;

        //    var chagnes = this.SnowRepository.GetAllCaseStateChanges(startDate, endDate, assigmentGroup, deltaHours);
        //    var hourData = new List<HourData>();

        //    for(DateTime i = startDate; i<=endDate;i=i.AddHours(1))
        //    {

        //        var hourTicketStates = new Dictionary<TicketState, int>();
        //        hourTicketStates.Add(TicketState.New, 0);
        //        hourTicketStates.Add(TicketState.In_Progress, 0);
        //        hourTicketStates.Add(TicketState.Awaiting_Customer, 0);
        //        hourTicketStates.Add(TicketState.Awaiting_Problem, 0);
        //        hourTicketStates.Add(TicketState.Awaiting_Change, 0);

        //        foreach (var item in chagnes)
        //        {
        //            var ticketState = item.GetStateForDateTime(i);


        //            switch (ticketState)
        //            {
        //                case TicketState.New:
        //                    hourTicketStates[TicketState.New] += 1;break;
        //                case TicketState.In_Progress:
        //                    hourTicketStates[TicketState.In_Progress] += 1; break;
        //                case TicketState.Awaiting_Customer:
        //                    hourTicketStates[TicketState.Awaiting_Customer] += 1; break;
        //                case TicketState.Awaiting_Problem:
        //                    hourTicketStates[TicketState.Awaiting_Problem] += 1; break;
        //                case TicketState.Awaiting_Change:
        //                    hourTicketStates[TicketState.Awaiting_Change] += 1; break;
        //                case TicketState.DefaultValue:
        //                    break;
        //            }

        //        }

        //        hourData.Add(new HourData(i.AddHours(timeZoneOffsetInHours), hourTicketStates));



        //    }


        //    return hourData;
        //    //return GenerateFakeDate(startDate, endDate, state);
        //}

        [HttpGet("GetRangedDate")]
        public List<HourData> GetRangedDate(DateTime startDate, DateTime endDate, string assigmentGroup, TicketLevels ticketsLevel, int timeZoneOffsetInHours = 0)
        {
            startDate = startDate.AddHours(-timeZoneOffsetInHours);
            endDate = endDate.AddHours(23).AddHours(-timeZoneOffsetInHours);

            int deltaHours = 300;


            

            var chagnes = this.SnowRepository.GetAllCaseStateChanges(startDate, endDate, assigmentGroup, deltaHours);
            var hourData = new List<HourData>();

            bool write = true;
            for (DateTime i = startDate; i <= endDate; i = i.AddHours(1))
            {
                //string logResult = $"{ticketsLevel} Time {i}:{Environment.NewLine}";



                var hourTicketStates = new Dictionary<string, int>();
                foreach (var state in this.SnowRepository.GetCaseStates())
                {
                    hourTicketStates.Add(state, 0);
                }

                foreach (var item in chagnes)
                {
                    var ticketState = item.GetStateForDateTime(i, ticketsLevel);

                    if (!string.IsNullOrEmpty(ticketState) && ticketState!="N/A")
                    {
                        hourTicketStates[ticketState] += 1;
                    }
                    //logResult += $"  {item.Id} -> {ticketState}{Environment.NewLine}";
                }

                hourData.Add(new HourData(i.AddHours(timeZoneOffsetInHours), hourTicketStates));

                //if (write)
                //{
                //    System.IO.File.AppendAllText("log.txt", logResult);
                //}
                //write = false;
            }


            return hourData;
        }
    }
}
