using DataAccess.Models;

namespace SnowReports.Models
{
    public class HourData
    {
        public HourData(DateTime date, Dictionary<string, int> value)
        {
            this.Date = date;
            this.Value = value;
        }
        public DateTime Date { get; set; }

        public Dictionary<string, int> Value { get; set; }
    }
}
