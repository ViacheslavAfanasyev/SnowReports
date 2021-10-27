using DataAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
    public partial class CasesContext : DbContext
    {
        public CasesContext()
        {

        }
        public CasesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseStateChange> CaseStateChanges { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Case>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("public_Cases");

                entity.Property(e => e.AffectedEnvImpact)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("affected_env_impact");

                entity.Property(e => e.AffectedEnvType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("affected_env_type");

                entity.Property(e => e.AffectedEnvUrl)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("affected_env_url");

                entity.Property(e => e.AffectedSoftware)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("affected_software");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(151)
                    .HasColumnName("assigned_to");

                entity.Property(e => e.AssignmentGroup)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group");

                entity.Property(e => e.AssignmentGroupInitial)
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_initial");

                entity.Property(e => e.AssignmentGroupRegion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_region");

                entity.Property(e => e.AssignmentGroupResolutionOwner)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_resolution_owner");

                entity.Property(e => e.AssignmentGroupTriageOwner)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_triage_owner");

                entity.Property(e => e.AssignmentGroupV2)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_v2");

                entity.Property(e => e.AssignmentGroupV3)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_v3");

                entity.Property(e => e.AssignmentGroupV4)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("assignment_group_v4");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("browser");

                entity.Property(e => e.Categories)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("categories");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(151)
                    .HasColumnName("contact");

                entity.Property(e => e.ContactEmployerType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("contact_employer_type");

                entity.Property(e => e.ContactEmployerTypeV2)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("contact_employer_type_v2");

                entity.Property(e => e.ContactEmployerTypeV3)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("contact_employer_type_v3");

                entity.Property(e => e.ContactOffice)
                    .HasMaxLength(8)
                    .HasColumnName("contact_office");

                entity.Property(e => e.CustomerCountry)
                    .HasMaxLength(128)
                    .HasColumnName("customer_country");

                entity.Property(e => e.CustomerCsm)
                    .HasMaxLength(255)
                    .HasColumnName("customer_csm");

                entity.Property(e => e.CustomerLicenseId)
                    .HasMaxLength(40)
                    .HasColumnName("customer_license_id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(256)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerOwner)
                    .HasMaxLength(80)
                    .HasColumnName("customer_owner");

                entity.Property(e => e.CustomerSfId)
                    .HasMaxLength(40)
                    .HasColumnName("customer_sf_id");

                entity.Property(e => e.CustomerSupportPlan)
                    .HasMaxLength(4000)
                    .HasColumnName("customer_support_plan");

                entity.Property(e => e.CustomerTimezone)
                    .HasMaxLength(4000)
                    .HasColumnName("customer_timezone");

                entity.Property(e => e.DateClosed)
                    .HasColumnType("datetime")
                    .HasColumnName("date_closed");

                entity.Property(e => e.DateClosedDay).HasColumnName("date_closed_day");

                entity.Property(e => e.DateClosedMonth).HasColumnName("date_closed_month");

                entity.Property(e => e.DateClosedQuarter).HasColumnName("date_closed_quarter");

                entity.Property(e => e.DateClosedWeek).HasColumnName("date_closed_week");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DateCreatedDay).HasColumnName("date_created_day");

                entity.Property(e => e.DateCreatedMonth).HasColumnName("date_created_month");

                entity.Property(e => e.DateCreatedQuarter).HasColumnName("date_created_quarter");

                entity.Property(e => e.DateCreatedWeek).HasColumnName("date_created_week");

                entity.Property(e => e.DateEscalated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_escalated");

                entity.Property(e => e.DateEscalatedDay).HasColumnName("date_escalated_day");

                entity.Property(e => e.DateEscalatedMonth).HasColumnName("date_escalated_month");

                entity.Property(e => e.DateEscalatedQuarter).HasColumnName("date_escalated_quarter");

                entity.Property(e => e.DateEscalatedWeek).HasColumnName("date_escalated_week");

                entity.Property(e => e.DateResolved)
                    .HasColumnType("datetime")
                    .HasColumnName("date_resolved");

                entity.Property(e => e.DateResolvedDay).HasColumnName("date_resolved_day");

                entity.Property(e => e.DateResolvedMonth).HasColumnName("date_resolved_month");

                entity.Property(e => e.DateResolvedQuarter).HasColumnName("date_resolved_quarter");

                entity.Property(e => e.DateResolvedWeek).HasColumnName("date_resolved_week");

                entity.Property(e => e.DateSurveyCompleted)
                    .HasColumnType("datetime")
                    .HasColumnName("date_survey_completed");

                entity.Property(e => e.DateSurveyCompletedDay).HasColumnName("date_survey_completed_day");

                entity.Property(e => e.DateSurveyCompletedMonth).HasColumnName("date_survey_completed_month");

                entity.Property(e => e.DateSurveyCompletedQuarter).HasColumnName("date_survey_completed_quarter");

                entity.Property(e => e.DateSurveyCompletedWeek).HasColumnName("date_survey_completed_week");

                entity.Property(e => e.DateSurveyExpiration)
                    .HasColumnType("datetime")
                    .HasColumnName("date_survey_expiration");

                entity.Property(e => e.DateSurveyExpirationDay).HasColumnName("date_survey_expiration_day");

                entity.Property(e => e.DateSurveyExpirationMonth).HasColumnName("date_survey_expiration_month");

                entity.Property(e => e.DateSurveyExpirationQuarter).HasColumnName("date_survey_expiration_quarter");

                entity.Property(e => e.DateSurveyExpirationWeek).HasColumnName("date_survey_expiration_week");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_updated");

                entity.Property(e => e.DateUpdatedDay).HasColumnName("date_updated_day");

                entity.Property(e => e.DateUpdatedMonth).HasColumnName("date_updated_month");

                entity.Property(e => e.DateUpdatedQuarter).HasColumnName("date_updated_quarter");

                entity.Property(e => e.DateUpdatedWeek).HasColumnName("date_updated_week");

                entity.Property(e => e.EscalatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("escalated_by");

                entity.Property(e => e.EscalationState)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("escalation_state");

                entity.Property(e => e.HideFromCustomer)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("hide_from_customer");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("id");

                entity.Property(e => e.IdOld)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("id_old");

                entity.Property(e => e.IdSys)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("id_sys");

                entity.Property(e => e.InfrastructureType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("infrastructure_type");

                entity.Property(e => e.InvestigationScope)
                    .HasMaxLength(4000)
                    .HasColumnName("investigation_scope");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("language");

                entity.Property(e => e.MetricRelationsChildCount).HasColumnName("metric_relations_child_count");

                entity.Property(e => e.MetricRelationsDevopsCount).HasColumnName("metric_relations_devops_count");

                entity.Property(e => e.MetricRelationsJiraCount).HasColumnName("metric_relations_jira_count");

                entity.Property(e => e.MetricWaitCloud)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("metric_wait_cloud");

                entity.Property(e => e.MetricWaitCustomer)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("metric_wait_customer");

                entity.Property(e => e.MetricWaitProduct)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("metric_wait_product");

                entity.Property(e => e.MetricWaitSupport)
                    .HasColumnType("numeric(18, 6)")
                    .HasColumnName("metric_wait_support");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("module");

                entity.Property(e => e.ModuleVersion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("module_version");

                entity.Property(e => e.ParentCustomerCountry)
                    .HasMaxLength(128)
                    .HasColumnName("parent_customer_country");

                entity.Property(e => e.ParentCustomerCsm)
                    .HasMaxLength(255)
                    .HasColumnName("parent_customer_csm");

                entity.Property(e => e.ParentCustomerName)
                    .HasMaxLength(256)
                    .HasColumnName("parent_customer_name");

                entity.Property(e => e.ParentCustomerOwner)
                    .HasMaxLength(80)
                    .HasColumnName("parent_customer_owner");

                entity.Property(e => e.ParentCustomerSfId)
                    .HasMaxLength(40)
                    .HasColumnName("parent_customer_sf_id");

                entity.Property(e => e.ParentCustomerTimezone)
                    .HasMaxLength(4000)
                    .HasColumnName("parent_customer_timezone");

                entity.Property(e => e.PartnerCountry)
                    .HasMaxLength(128)
                    .HasColumnName("partner_country");

                entity.Property(e => e.PartnerCsm)
                    .HasMaxLength(255)
                    .HasColumnName("partner_csm");

                entity.Property(e => e.PartnerName)
                    .HasMaxLength(256)
                    .HasColumnName("partner_name");

                entity.Property(e => e.PartnerOwner)
                    .HasMaxLength(80)
                    .HasColumnName("partner_owner");

                entity.Property(e => e.PartnerSfId)
                    .HasMaxLength(40)
                    .HasColumnName("partner_sf_id");

                entity.Property(e => e.PartnerTimezone)
                    .HasMaxLength(4000)
                    .HasColumnName("partner_timezone");

                entity.Property(e => e.PreferredTimezone)
                    .HasMaxLength(4000)
                    .HasColumnName("preferred_timezone");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("priority");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product");

                entity.Property(e => e.ProductV2)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("product_v2");

                entity.Property(e => e.ProductV3)
                    .HasMaxLength(4000)
                    .HasColumnName("product_v3");

                entity.Property(e => e.ProductV4)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("product_v4");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_version");

                entity.Property(e => e.QueueWeight)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("queue_weight");

                entity.Property(e => e.ResolutionTimeBucket)
                    .HasMaxLength(23)
                    .IsUnicode(false)
                    .HasColumnName("resolution_time_bucket");

                entity.Property(e => e.ResolutionTimeDays)
                    .HasColumnType("decimal(5, 1)")
                    .HasColumnName("resolution_time_days");

                entity.Property(e => e.ResolvedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("resolved_by");

                entity.Property(e => e.RootCause)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("root_cause");

                entity.Property(e => e.ScFollowTheSun)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("sc_follow_the_sun");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("short_description");

                entity.Property(e => e.Stage)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("stage");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("state");

                entity.Property(e => e.SupportLevel)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("support_level");

                entity.Property(e => e.SurveyActionsTaken).HasColumnName("survey_actions_taken");

                entity.Property(e => e.SurveyComment).HasColumnName("survey_comment");

                entity.Property(e => e.SurveyEvaluation).HasColumnName("survey_evaluation");

                entity.Property(e => e.SurveyGeneral)
                    .HasMaxLength(10)
                    .HasColumnName("survey_general");

                entity.Property(e => e.SurveyKnowledge)
                    .HasMaxLength(10)
                    .HasColumnName("survey_knowledge");

                entity.Property(e => e.SurveyRecommend)
                    .HasMaxLength(10)
                    .HasColumnName("survey_recommend");

                entity.Property(e => e.SurveyResolution)
                    .HasMaxLength(10)
                    .HasColumnName("survey_resolution");

                entity.Property(e => e.SurveyRootCauseCode)
                    .HasMaxLength(100)
                    .HasColumnName("survey_root_cause_code");

                entity.Property(e => e.SurveySpeed)
                    .HasMaxLength(10)
                    .HasColumnName("survey_speed");

                entity.Property(e => e.TotalTimeWorked)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("total_time_worked");

                entity.Property(e => e.TotalTimeWorkedBucket)
                    .IsRequired()
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("total_time_worked_bucket");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("type");

                entity.Property(e => e.WebServer)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("web_server");
            });

            modelBuilder.Entity<CaseStateChange>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("public_CaseStateChanges");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(100)
                    .HasColumnName("assigned_to");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(40)
                    .HasColumnName("case_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .HasColumnName("state");

                entity.Property(e => e.StateChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("state_change_date");

                entity.Property(e => e.StateChangeDateDay).HasColumnName("state_change_date_day");

                entity.Property(e => e.StateChangeDateMonth).HasColumnName("state_change_date_month");

                entity.Property(e => e.StateChangeDateQuarter).HasColumnName("state_change_date_quarter");

                entity.Property(e => e.StateChangeDateWeek).HasColumnName("state_change_date_week");

                entity.Property(e => e.StateDurationHours)
                    .HasColumnType("numeric(17, 6)")
                    .HasColumnName("state_duration_hours");

                entity.Property(e => e.StateDurationHoursBucket)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state_duration_hours_bucket");

                entity.Property(e => e.StateDurationWeekdayHours)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("state_duration_weekday_hours");

                entity.Property(e => e.StateDurationWeekdayHoursBucket)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("state_duration_weekday_hours_bucket");

                entity.Property(e => e.SupportLevel)
                    .HasMaxLength(2)
                    .HasColumnName("support_level");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        */

    }
}
