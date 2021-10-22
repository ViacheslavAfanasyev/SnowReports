using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISnowReportsRepository : IDisposable
    {
        IEnumerable<CaseStateChange> GetAllCaseStateChanges(DateTime startDate, DateTime endDate);
        IEnumerable<CaseStateChange> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, TicketState ticketState);
       
    }
}
