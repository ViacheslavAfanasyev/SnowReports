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
        public List<UniqueCase> GetAllCaseStateChanges(DateTime startDate, DateTime endDate, string assignmentGroup, int correctionDeltaHours);
        public IEnumerable<string> GetCaseStates();
        public IEnumerable<string> GetTechSupportAssignmentGroups(string filterValue, bool includeAccumulatedGroup);

    }
}
