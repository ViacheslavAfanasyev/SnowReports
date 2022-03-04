using DataAccess.DataAccess;
using DataAccess.Models;
using Logging;
using Microsoft.Extensions.Logging;
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
        ILogger<FileLogger> Logger;
        public SnowReportsRepository(CasesContext dbContext, ILogger<FileLogger> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger;
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

        private List<UniqueCase> GetUniqueCase(DateTime startDate, DateTime endDate, string assignmentGroup)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            
            var lastTicketTime = this.DbContext.Cases.OrderByDescending(s => s.DateUpdated).Select(s => s.DateUpdated);
            UniqueCase.LastTicketTime = lastTicketTime.FirstOrDefault();
            
            watch.Stop();
            this.Logger.LogInformation($"Last case update date took -> {watch.ElapsedMilliseconds} ms");



            var watch1 = new System.Diagnostics.Stopwatch();
            watch1.Start();

            var handledAssigmentGroups = GetTechSupportAssignmentGroups(String.Empty, true);


            bool includeState = false;
            
            var query = from c in this.DbContext.Cases
                        where (c.DateClosed >= startDate || c.DateClosed == UniqueCase.DefaultCaseDateTime)
                        && c.DateCreated <= endDate
                        && handledAssigmentGroups.Contains(c.AssignmentGroup)
                        join csc in this.DbContext.CaseStateChanges on c.Id equals csc.CaseId
                        //where csc.SupportLevel.Contains(ticketsLevel)
                         select new
                         {
                             CaseId = csc.CaseId,
                             State = csc.State,
                             StateChangeDate = csc.StateChangeDate,
                             AssignmentGroup = c.AssignmentGroup,
                             CreatedDate = c.DateCreated,
                             ClosedDate = c.DateClosed,
                             Level = csc.SupportLevel//.Trim()
                         };

            


            var uniqueCases = new List<UniqueCase>();

            var cxsmksadcms = query.Count();

            //Microsoft.Data.SqlClient.SqlException
            foreach (var item in query)
            {
                try
                {
                    var uniqueCase = uniqueCases.FirstOrDefault(u => u.Id == item.CaseId);
                    if (uniqueCase == null)
                    {
                        if (!assignmentGroup.Contains("All of"))
                        {
                            if (item.AssignmentGroup == null || item.AssignmentGroup != null && item.AssignmentGroup != assignmentGroup)
                            {
                                continue;
                            }
                        }
                        else if (item.AssignmentGroup == null || !handledAssigmentGroups.Contains(item.AssignmentGroup))
                        {
                            continue;
                        }

                        uniqueCase = new UniqueCase(item.CaseId, item.CreatedDate, item.ClosedDate);
                        uniqueCases.Add(uniqueCase);
                    }

                    uniqueCase.States.Add(new CaseStateChange(item.State, item.StateChangeDate, item.Level));
                }
                catch(Exception ex)
                {
                    throw new Exception($"{item.CaseId} {item.StateChangeDate}{Environment.NewLine} {ex.Message} {ex.StackTrace}");
                }

            }


            watch1.Stop();
            this.Logger.LogInformation($"Retrieving cases states({uniqueCases.Count}) from db took -> {watch1.ElapsedMilliseconds} ms | {startDate} - {endDate}");

            return uniqueCases;
        }


        public List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, string assignmentGroup, int correctionDeltaHours)
        {
            var results = this.GetUniqueCase(startDate, endDate, assignmentGroup);

            return results;
        }

        public IEnumerable<string> GetCaseStates()
        {
            try
            {
                if (SnowCache.States.Count != 0)
                {
                    return SnowCache.States;
                }
                return SnowCache.States = this.DbContext.CaseStateChanges.Select(s => s.State).Distinct().Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Timeout expired."))
                {
                    return new List<string>() { "Timeout expired." };
                }
                throw;
            }
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
