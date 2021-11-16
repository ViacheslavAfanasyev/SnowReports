using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CaseStateChange : IComparable
    {
        public static DateTime LastTicketTime = DateTime.MaxValue;
        public CaseStateChange(string stateEntered, DateTime entereddate, string level)
        {
            this.EnteredDate = entereddate;
            this.StateEntered = stateEntered;

            if (level=="1")
            {
                this.Level = TicketLevels.L1;
            }
            else if (level=="2")
            {
                this.Level = TicketLevels.L2;
            }
        }
        public string StateEntered { get; set; }
        public DateTime EnteredDate { get; set; }

        public TicketLevels Level { get; set; }
        
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
