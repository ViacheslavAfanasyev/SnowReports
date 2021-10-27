using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CaseStateChange : IComparable
    {
        public CaseStateChange(string stateEntered, DateTime entereddate)
        {
            //this.Id = id;

            object stateEnteredResult = null;
            Enum.TryParse(typeof(TicketState), stateEntered.Replace(' ','_'), out stateEnteredResult);
            this.EnteredDate = entereddate;
            this.StateEntered = (TicketState)stateEnteredResult;
        }
        public TicketState StateEntered { get; set; }
        public DateTime EnteredDate { get; set; }

        public int CompareTo(object? obj)
        {
            if (obj==null)
                return 1;

            var comparedCaseStateChange = (obj as CaseStateChange);

            if (comparedCaseStateChange != null)
                return this.EnteredDate.CompareTo(comparedCaseStateChange.EnteredDate);
            else throw new ArgumentException("Object is not a CaseStateChange");
        }
    }
}
