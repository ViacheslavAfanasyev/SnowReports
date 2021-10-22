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
        public List<DailyData> GetRangedDate(DateTime startDate, DateTime endDate, TicketState state)
        {
            var chagnes = this.SnowRepository.GetAllCaseStateChanges(startDate, endDate, state);

            return GenerateFakeDate(startDate, endDate, state);
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
