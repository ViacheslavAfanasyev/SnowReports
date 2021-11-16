using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public enum TicketState
    {
        New,
        In_Progress,
        Awaiting_Customer,
        Awaiting_Problem,
        Awaiting_Change,
    }
}
