using DataAccess.Models;

namespace SnowReports.Models
{
    public class DailyDataSet
    {
        public DailyDataSet(TicketState state, IEnumerable<DailyData> dailyData)
        {
            this.State = state;
            this.DailyData = dailyData;
        }
        public TicketState State { get; set; }
        public IEnumerable<DailyData> DailyData { get; set; }
    }
}
