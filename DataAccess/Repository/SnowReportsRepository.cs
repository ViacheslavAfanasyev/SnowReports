using DataAccess.DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SnowReportsRepository : ISnowReportsRepository
    {
        CasesContext DbContext;
        public SnowReportsRepository(CasesContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        private List<UniqueCase> GetUniqueCase(DateTime startDate, DateTime endDate, AssignmentGroup assignmentGroup, int correctionDeltaHours)
        {
            

            startDate = startDate.AddHours(-correctionDeltaHours);

            var query = from c in this.DbContext.CaseStateChanges
                        where c.StartDate >= startDate && c.StartDate <= endDate
                        join ci in this.DbContext.Cases on c.CaseId equals ci.Id
                        select new
                        {
                            CaseId = c.CaseId,
                            State = c.State,
                            StateChangeDate = c.StateChangeDate,
                            AssignmentGroup = ci.AssignmentGroup
                        };



            var uniqueCases = new List<UniqueCase>();

            //Microsoft.Data.SqlClient.SqlException
            foreach (var item in query)
            {
                var uniqueCase = uniqueCases.FirstOrDefault(u => u.Id == item.CaseId);
                if (uniqueCase == null)
                {
                    object aG = null;
                    Enum.TryParse(typeof(AssignmentGroup), item.AssignmentGroup.Replace(' ', '_'), out aG);

                    if (assignmentGroup != AssignmentGroup.Any)
                    {
                        if (aG == null || aG != null && (AssignmentGroup)aG != assignmentGroup)
                        {
                            continue;
                        }
                    }

                    uniqueCase = new UniqueCase(item.CaseId);
                    uniqueCases.Add(uniqueCase);
                }

                uniqueCase.States.Add(new CaseStateChange(item.State, item.StateChangeDate));

            }


            //foreach (var item in this.DbContext.CaseStateChanges.Where(c => c.StartDate >= startDate && c.StartDate <= endDate))
            //{
            //    var uniqueCase = uniqueCases.FirstOrDefault(u => u.Id == item.CaseId);
            //    if (uniqueCase == null)
            //    {
            //        //var caseAssignmentGroup = this.DbContext.Cases.FirstOrDefault(c => c.Id == item.CaseId)?.AssignmentGroup;

            //        object aG = null;
            //        //Enum.TryParse(typeof(AssignmentGroup), caseAssignmentGroup.Replace(' ', '_'), out aG);



            //        //if (aG != null && !(assignmentGroup == AssignmentGroup.Any) || (AssignmentGroup)aG != assignmentGroup)
            //        //{
            //        //    continue;
            //        //}

            //        uniqueCase = new UniqueCase(item.CaseId);
            //        uniqueCases.Add(uniqueCase);
            //    }

            //    uniqueCase.States.Add(new CaseStateChange(item.State, item.StateChangeDate));

            //}

            return uniqueCases;
        }


        public List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, AssignmentGroup assignmentGroup, int correctionDeltaHours)
        {
            var results = this.GetUniqueCase(startDate, endDate, assignmentGroup, correctionDeltaHours);

            return results;
        }
    }
}
