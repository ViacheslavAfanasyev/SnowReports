using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UniqueCase
    {
        public static DateTime DefaultCaseDateTime = DateTime.Parse("1/1/1900 12:00:00 AM");
        public UniqueCase(string id, DateTime createdDate, DateTime closedDate)
        {
            this.Id = id;
            this.CreatedDate = createdDate;
            this.ClosedDate = closedDate;
            this.States = new List<CaseStateChange>();
        }
        public string Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ClosedDate { get; private set; }
        public List<CaseStateChange> States { get; private set; }

        //public TicketState GetStateForDateTime(DateTime time)
        //{
        //    if (time>DateTime.UtcNow)
        //    {
        //        return TicketState.DefaultValue;
        //    }

        //    var ll = this.States.Where(t => t.EnteredDate <= time);
        //    var caseStateChange = this.States.Where(t => t.EnteredDate <= time).Max();

        //    if (caseStateChange!=null)
        //    {
        //        return caseStateChange.StateEntered;
        //    }
        //    return TicketState.DefaultValue;
        //}

        public string GetStateForDateTime(DateTime time)
        {
            if (time > DateTime.UtcNow)
            {
                return "N/A";
            }

            var ll = this.States.Where(t => t.EnteredDate <= time);
            var caseStateChange = this.States.Where(t => t.EnteredDate <= time).Max();

            if (caseStateChange != null)
            {
                if (this.ClosedDate != UniqueCase.DefaultCaseDateTime && this.ClosedDate<time)
                {
                    return "N/A";//Closed
                }
                return caseStateChange.StateEntered;
            }
            return "N/A";
        }


    }
}
