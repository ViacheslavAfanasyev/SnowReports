using Microsoft.AspNetCore.Mvc;
using SnowReports.Models;
using DataAccess.Models;
using DataAccess.Extensions;

namespace SnowReports.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("States")]
        public Dictionary<int, string> States()
        {
            return typeof(TicketState).ToDictionary();
        }

        [HttpGet("AssignmentGroups")]
        public Dictionary<int, string> AssignmentGroups()
        {
            return typeof(AssignmentGroup).ToDictionary();
        }
    }
}
