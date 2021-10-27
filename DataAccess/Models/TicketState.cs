//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public enum TicketState
    {
        New,
        [Display(Name ="In Progress")]
        In_Progress,
        [Display(Name = "Awaiting Customer")]
        Awaiting_Customer,
        [Display(Name = "Awaiting Problem")]
        Awaiting_Problem,
        [Display(Name = "Awaiting Change")]
        Awaiting_Change,
        
        DefaultValue
    }
}
