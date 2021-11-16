using Microsoft.Extensions.Logging;
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
        public static DateTime LastTicketTime = DateTime.MaxValue;
        public UniqueCase(string id, DateTime createdDate, DateTime closedDate)
        {
            this.Id = id;
            this.CreatedDate = createdDate;
            this.ClosedDate = closedDate;
            this.States = new List<CaseStateChange>();
            this.LevelChangeTimeCalculated = false;
            this.HasLevelBeenChanged = false;
            this.HasL1States = false;
            this.HasL2States = false;
        }
        public string Id { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ClosedDate { get; private set; }
        public List<CaseStateChange> States { get; private set; }

        public bool LevelChangeTimeCalculated { get; private set; }
        public bool HasLevelBeenChanged { get; private set; }

        public bool HasL1States { get; private set; }
        public bool HasL2States { get; private set; }

        public DateTime LevelChangeTime { get; private set; }

        //public string GetStateForDateTime(DateTime time)
        //{
        //    if (time > DateTime.UtcNow)
        //    {
        //        return "N/A";
        //    }

        //    var ll = this.States.Where(t => t.EnteredDate <= time);
        //    var caseStateChange = this.States.Where(t => t.EnteredDate <= time).Max();

        //    if (caseStateChange != null)
        //    {
        //        if (this.ClosedDate != UniqueCase.DefaultCaseDateTime && this.ClosedDate<time)
        //        {
        //            return "N/A";//Closed
        //        }
        //        return caseStateChange.StateEntered;
        //    }
        //    return "N/A";
        //}


        public string GetStateForDateTime(DateTime time, TicketLevels ticketsLevel)
        {

                if (!this.LevelChangeTimeCalculated)
                {
                    CalculateLevelChangeTimeCalculated();
                }

                if (time > UniqueCase.LastTicketTime)
                {
                    return "N/A";
                }

                if (ticketsLevel == TicketLevels.L1 && !this.HasL1States)
                {
                    return "N/A";
                }

                if (ticketsLevel == TicketLevels.L2 && !this.HasL2States)
                {
                    return "N/A";
                }

                if (ticketsLevel == TicketLevels.L1 && this.HasLevelBeenChanged && this.LevelChangeTime < time)
                {
                    return "N/A";
                }

                if (ticketsLevel == TicketLevels.L2 && this.HasLevelBeenChanged && this.LevelChangeTime > time)
                {
                     return "N/A";
                }

                CaseStateChange caseStateChange = null;

                if (ticketsLevel == TicketLevels.All)
                {
                    caseStateChange = this.States.Where(t => t.EnteredDate <= time).Max();
                }
                else
                {
                    caseStateChange = this.States.Where(t => t.EnteredDate <= time && t.Level == ticketsLevel).Max();
                }


                if (caseStateChange != null)
                {
                    if (this.ClosedDate != UniqueCase.DefaultCaseDateTime && this.ClosedDate < time)
                    {
                        return "N/A";//Closed
                    }
                    return caseStateChange.StateEntered;
                }
                 return "N/A";
            
        }

        public void CalculateLevelChangeTimeCalculated()
        {
           this.LevelChangeTimeCalculated = true;
           var maxL1 = this.States.Where(s => s.Level == TicketLevels.L1).Max();
           var minL2 = this.States.Where(s => s.Level == TicketLevels.L2).Min();


            if (maxL1 !=null && minL2 != null)
            {
                this.HasL1States = true;
                this.HasL2States = true;
                this.HasLevelBeenChanged = true;
                if (minL2.EnteredDate.Subtract(maxL1.EnteredDate) > TimeSpan.FromHours(1))
                {
                    this.LevelChangeTime = maxL1.EnteredDate.AddHours(1);

                }
                else
                {
                    this.LevelChangeTime = maxL1.EnteredDate.AddMinutes(minL2.EnteredDate.Subtract(maxL1.EnteredDate).Minutes / 2);
                }

                this.States.Add(new CaseStateChange("In Progress", this.LevelChangeTime, "L2"));
            }
            else
            {
                if (maxL1!=null)
                {
                    this.HasL1States = true;
                }
                if (minL2!=null)
                {
                    this.HasL2States=true;
                }
            }
        }
    }
}
