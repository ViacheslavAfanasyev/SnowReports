using DataAccess.Models;

namespace SnowReports.Models
{
    public class HourData
    {
        public HourData(DateTime date, Dictionary<TicketState, int> value)
        {
            this.Date = date;
            this.Value = value;
        }
        public DateTime Date { get; set; }

        public Dictionary<TicketState, int> Value { get; set; }
    }
}
