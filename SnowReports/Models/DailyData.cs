using DataAccess.Models;

namespace SnowReports.Models
{
    public class DailyData
    {
        public DailyData(DateTime date, Dictionary<TicketState, int> value)
        {
            this.Date = date.Date;
            this.Value = value;
        }
        public DateTime Date { get; set; }

        public Dictionary<TicketState, int> Value {  get; set; }

    }
}
