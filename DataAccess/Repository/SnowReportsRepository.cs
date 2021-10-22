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

        public IEnumerable<CaseStateChange> GetAllCaseStateChanges(DateTime startDate, DateTime endDate)
        {
            return this.DbContext.CaseStateChanges.Where(c => c.StartDate >= startDate && c.StartDate <= endDate);
        }

        public IEnumerable<CaseStateChange> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, TicketState ticketState)
        {
            return this.DbContext.CaseStateChanges.Where(c => c.StartDate >= startDate && c.StartDate <= endDate && c.State == ticketState.ToString());
        }
    }
}
