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

        private List<UniqueCase> GetUniqueCase(DateTime startDate, DateTime endDate, string assignmentGroup, int correctionDeltaHours)
        {

            //if (false)
            //{
            //    var handledAssigmentGroups = GetTechSupportAssignmentGroups(String.Empty, true);

            //    startDate = startDate.AddHours(-correctionDeltaHours);

            //    var query = from c in this.DbContext.CaseStateChanges
            //                where c.StartDate >= startDate && c.StartDate <= endDate
            //                join ci in this.DbContext.Cases on c.CaseId equals ci.Id
            //                where handledAssigmentGroups.Contains(ci.AssignmentGroup)
            //                select new
            //                {
            //                    CaseId = c.CaseId,
            //                    State = c.State,
            //                    StateChangeDate = c.StateChangeDate,
            //                    AssignmentGroup = ci.AssignmentGroup,
            //                    CreatedDate = ci.DateCreated,
            //                    ClosedDate = ci.DateClosed
            //                };

            //}




            var handledAssigmentGroups = GetTechSupportAssignmentGroups(String.Empty, true);

            startDate = startDate.AddHours(-correctionDeltaHours);

            var query = from c in this.DbContext.Cases
                         where (c.DateClosed >= startDate || c.DateClosed == UniqueCase.DefaultCaseDateTime)
                         && c.DateCreated <= endDate
                         && handledAssigmentGroups.Contains(c.AssignmentGroup)
                         join csc in this.DbContext.CaseStateChanges on c.Id equals csc.CaseId
                         select new
                         {
                             CaseId = csc.CaseId,
                             State = csc.State,
                             StateChangeDate = csc.StateChangeDate,
                             AssignmentGroup = c.AssignmentGroup,
                             CreatedDate = c.DateCreated,
                             ClosedDate = c.DateClosed
                         };

            //var query1 = from c in this.DbContext.CaseStateChanges
            //            where c.StartDate >= startDate && c.StartDate <= endDate
            //            join ci in this.DbContext.Cases on c.CaseId equals ci.Id
            //            where handledAssigmentGroups.Contains(ci.AssignmentGroup)
            //            select new
            //            {
            //                CaseId = c.CaseId,
            //                State = c.State,
            //                StateChangeDate = c.StateChangeDate,
            //                AssignmentGroup = ci.AssignmentGroup,
            //                CreatedDate = ci.DateCreated,
            //                ClosedDate = ci.DateClosed
            //            };





            var uniqueCases = new List<UniqueCase>();

            //Microsoft.Data.SqlClient.SqlException
            foreach (var item in query)
            {
                var uniqueCase = uniqueCases.FirstOrDefault(u => u.Id == item.CaseId);
                if (uniqueCase == null)
                {
                    //object aG = null;
                    //Enum.TryParse(typeof(AssignmentGroup), item.AssignmentGroup.Replace(' ', '_'), out aG);
                    

                    if (!assignmentGroup.Contains("All of"))
                    {
                        if (item.AssignmentGroup == null || item.AssignmentGroup != null && item.AssignmentGroup != assignmentGroup)
                        {
                            continue;
                        }
                    }
                    else if(item.AssignmentGroup == null || !handledAssigmentGroups.Contains(item.AssignmentGroup))
                    {
                        continue;
                    }

                    uniqueCase = new UniqueCase(item.CaseId, item.CreatedDate, item.ClosedDate);
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


        public List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, string assignmentGroup, int correctionDeltaHours)
        {
            var results = this.GetUniqueCase(startDate, endDate, assignmentGroup, correctionDeltaHours);

            return results;
        }

        public IEnumerable<string> GetCaseStates()
        {
            if (SnowCache.States.Count!=0)
            {
                return SnowCache.States;
            }
            return SnowCache.States = this.DbContext.CaseStateChanges.Select(s => s.State).Distinct().ToList();
        }

        public IEnumerable<string> GetTechSupportAssignmentGroups(string filterValue, bool includeAccumulatedGroup)
        {
            if (SnowCache.AssigmentGroups.Count != 0)
            {
                if (includeAccumulatedGroup)
                {
                    return SnowCache.AccumulatedAssigmentGroups;
                }
                return SnowCache.AssigmentGroups;
            }
            else
            {
                List<string> results = new List<string>();

                if (string.IsNullOrEmpty(filterValue))
                {
                    results.AddRange(this.DbContext.Cases.Select(s => s.AssignmentGroup).Distinct());
                }
                else
                {
                    results.AddRange(this.DbContext.Cases.Where(c => c.AssignmentGroupV3 == filterValue).Select(s => s.AssignmentGroup).Distinct());
                }
                SnowCache.AssigmentGroups = results;

                var accumulatedResults = new List<string>();
                accumulatedResults.Add($"All of {filterValue}");
                accumulatedResults.AddRange(SnowCache.AssigmentGroups);

                SnowCache.AccumulatedAssigmentGroups = accumulatedResults;
            }

            if (includeAccumulatedGroup)
            {
                 return SnowCache.AccumulatedAssigmentGroups;
            }
            return SnowCache.AssigmentGroups;

        }
    }
}
