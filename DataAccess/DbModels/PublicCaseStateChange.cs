using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.DbModels
{
    [Table("Public_CaseStateChanges")]
    [Keyless]
    public partial class CaseStateChange
    {
        [Column("case_id")]
        public string CaseId { get; set; }
        public string State { get; set; }
        [Column("Assigned_To")]
        public string AssignedTo { get; set; }

        [Column("Support_Level")]
        public string SupportLevel { get; set; }

        [Column("State_Duration_Hours")]
        public decimal? StateDurationHours { get; set; }
        [Column("State_Duration_Hours_Bucket")]
        public string StateDurationHoursBucket { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("State_Duration_Weekday_Hours")]
        public decimal? StateDurationWeekdayHours { get; set; }
        [Column("State_Duration_Weekday_Hours_Bucket")]
        public string StateDurationWeekdayHoursBucket { get; set; }

        [Column("state_change_date")]
        public DateTime StateChangeDate { get; set; }

        [Column("state_change_date_Day")]
        public int? StateChangeDateDay { get; set; }
        [Column("state_change_date_week")]
        public int? StateChangeDateWeek { get; set; }
        [Column("state_change_date_month")]
        public int? StateChangeDateMonth { get; set; }
        [Column("state_change_date_quarter")]
        public int? StateChangeDateQuarter { get; set; }
    }
}
