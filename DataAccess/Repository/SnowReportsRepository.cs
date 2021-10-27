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

        private List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, int correctionDeltaHours)
        {
            startDate = startDate.AddHours(-correctionDeltaHours);

            var uniqueCases = new List<UniqueCase>();
            foreach (var item in this.DbContext.CaseStateChanges.Where(c => c.StartDate >= startDate && c.StartDate <= endDate))
            {
                var uniqueCase = uniqueCases.FirstOrDefault(u => u.Id == item.CaseId);
                if (uniqueCase == null)
                {
                    uniqueCase = new UniqueCase(item.CaseId);
                    uniqueCases.Add(uniqueCase);
                }

                uniqueCase.States.Add(new CaseStateChange(item.State, item.StateChangeDate));

            }

            return uniqueCases;
        }


        public List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate)
        {
            var results = this.GetAllCaseStateChanges(startDate, endDate, 40);

            return results;
        }
    }
}
