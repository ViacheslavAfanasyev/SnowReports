using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UniqueCase
    {
        public UniqueCase(string id)
        {
            this.Id = id;
            this.States = new List<CaseStateChange>();
        }
        public string Id { get; set; }
        public List<CaseStateChange> States { get; set; }

        public TicketState GetStateForDateTime(DateTime time)
        {
            var ll = this.States.Where(t => t.EnteredDate <= time);
            var caseStateChange = this.States.Where(t => t.EnteredDate <= time).Max();

            if (caseStateChange!=null)
            {
                return caseStateChange.StateEntered;
            }
            return TicketState.DefaultValue;
        }


    }
}
