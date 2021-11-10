using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.DbModels
{
    [Table("Public_Cases")]
    [Keyless]
    public partial class Case
    {
        public Case()
        {
            this.Id = "";
            this.IdSys = "";
            this.IdOld = "";
            this.State = "z";
            this.Stage = "z";
            this.ShortDescription = "z";
            this.InvestigationScope = "z";
            this.Priority = "z";
            AssignedTo = "z";
            AssignmentGroup = "z";
            AssignmentGroupV2 = "z";
            AssignmentGroupV3 = "z";
            AssignmentGroupV4 = "z";
            AssignmentGroupInitial = "z";
            AssignmentGroupRegion = "z";
            AssignmentGroupResolutionOwner = "z";
            AssignmentGroupTriageOwner = "z";
            SupportLevel = "z";
            AffectedSoftware = "z";
            Product = "z";
            ProductVersion = "z";
            ProductV2 = "z";
            ProductV3 = "z";
            ProductV4 = "z";
            Module = "z";
            ModuleVersion = "z";
            ScFollowTheSun = "z";
            EscalationState = "z";
            EscalatedBy = "z";
            TotalTimeWorked = 0;
            TotalTimeWorkedBucket = "z";
            Type = "z";
            AffectedEnvType = "z";
            AffectedEnvImpact = "z";
            AffectedEnvUrl = "z";
            Categories = "z";
            WebServer = "z";
            InfrastructureType = "z";
            Browser = "z";
            Language = "z";
            RootCause = "z";
            ResolvedBy = "z";
            QueueWeight = "z";
            ResolutionTimeDays = 0;
            ResolutionTimeBucket = "z";
            HideFromCustomer = "z";
            Contact = "z";
            ContactEmployerType = "z";
            ContactEmployerTypeV2 = "z";
            ContactEmployerTypeV3 = "z";
            ContactOffice = "z";
            PreferredTimezone = "z";
            PartnerName = "z";
            PartnerCountry = "z";
            PartnerTimezone = "z";
            PartnerOwner = "z";
            PartnerCsm = "z";
            PartnerSfId = "z";
            CustomerName = "z";
            CustomerCountry = "z";
            CustomerTimezone = "z";
            CustomerOwner = "z";
            CustomerCsm = "z";
            CustomerSfId = "z";
            ParentCustomerName = "z";
            ParentCustomerCountry = "z";
            ParentCustomerTimezone = "z";
            ParentCustomerOwner = "z";
            ParentCustomerCsm = "z";
            ParentCustomerSfId = "z";
            CustomerLicenseId = "z";
            CustomerSupportPlan = "z";
            MetricWaitSupport = 0;
            MetricWaitCloud = 0;
            MetricWaitProduct = 0;
            MetricWaitCustomer = 0;
            MetricRelationsJiraCount = 0;
            MetricRelationsDevopsCount = 0;
            MetricRelationsChildCount = 0;
            DateCreated = DateTime.Now;
            DateCreatedDay = 0;
            DateCreatedWeek = 0;
            DateCreatedMonth = 0;
            DateCreatedQuarter = 0;
            DateUpdated = DateTime.Now;
            DateUpdatedDay = 0;
            DateUpdatedWeek = 0;
            DateUpdatedMonth = 0;
            DateUpdatedQuarter = 0;
            DateResolved = DateTime.Now;
            DateResolvedDay = 0;
            DateResolvedWeek = 0;
            DateResolvedMonth = 0;
            DateResolvedQuarter = 0;
            DateClosed = DateTime.Now;
            DateClosedDay = 0;
            DateClosedWeek = 0;
            DateClosedMonth = 0;
            DateClosedQuarter = 0;
            DateEscalated = DateTime.Now;
            DateEscalatedDay = 0;
            DateEscalatedWeek = 0;
            DateEscalatedMonth = 0;
            DateEscalatedQuarter = 0;
            DateSurveyExpiration = DateTime.Now;
            DateSurveyExpirationDay = 0;
            DateSurveyExpirationWeek = 0;
            DateSurveyExpirationMonth = 0;
            DateSurveyExpirationQuarter = 0;
            DateSurveyCompleted = DateTime.Now;
            DateSurveyCompletedDay = 0;
            DateSurveyCompletedWeek = 0;
            DateSurveyCompletedMonth = 0;
            DateSurveyCompletedQuarter = 0;
            SurveyGeneral = "z";
            SurveyResolution = "z";
            SurveyKnowledge = "z";
            SurveySpeed = "z";
            SurveyRecommend = "z";
            SurveyComment = "z";
            SurveyEvaluation = "z";
            SurveyActionsTaken = "z";
            SurveyRootCauseCode = "z";
        }
        public string Id { get; set; }
        [Column("Id_Sys")]
        public string IdSys { get; set; }
        [Column("Id_Old")]
        public string IdOld { get; set; }
        public string State { get; set; }
        public string Stage { get; set; }
        [Column("Short_Description")]
        public string ShortDescription { get; set; }
        [Column("Investigation_Scope")]
        public string InvestigationScope { get; set; }
        public string Priority { get; set; }
        [Column("Assigned_To")]
        public string AssignedTo { get; set; }
        [Column("Assignment_Group")]
        public string AssignmentGroup { get; set; }
        [Column("Assignment_Group_V2")]
        public string AssignmentGroupV2 { get; set; }
        [Column("Assignment_Group_V3")]
        public string AssignmentGroupV3 { get; set; }
        [Column("Assignment_Group_V4")]
        public string AssignmentGroupV4 { get; set; }
        [Column("Assignment_Group_Initial")]
        public string AssignmentGroupInitial { get; set; }
        [Column("Assignment_Group_Region")]
        public string AssignmentGroupRegion { get; set; }
        [Column("Assignment_Group_Resolution_Owner")]
        public string AssignmentGroupResolutionOwner { get; set; }
        [Column("Assignment_Group_Triage_Owner")]
        public string AssignmentGroupTriageOwner { get; set; }
        [Column("Support_Level")]
        public string SupportLevel { get; set; }
        [Column("Affected_Software")]
        public string AffectedSoftware { get; set; }
        public string Product { get; set; }
        [Column("Product_Version")]
        public string ProductVersion { get; set; }
        [Column("Product_V2")]
        public string ProductV2 { get; set; }
        [Column("Product_V3")]
        public string ProductV3 { get; set; }
        [Column("Product_V4")]
        public string ProductV4 { get; set; }
        public string Module { get; set; }
        [Column("Module_Version")]
        public string ModuleVersion { get; set; }
        [Column("Sc_Follow_The_Sun")]
        public string ScFollowTheSun { get; set; }
        [Column("Escalation_State")]
        public string EscalationState { get; set; }
        [Column("Escalated_By")]
        public string EscalatedBy { get; set; }
        [Column("Total_Time_Worked")]
        public decimal? TotalTimeWorked { get; set; }
        [Column("Total_Time_Worked_Bucket")]
        public string TotalTimeWorkedBucket { get; set; }
        public string Type { get; set; }
        [Column("Affected_Env_Type")]
        public string AffectedEnvType { get; set; }
        [Column("Affected_Env_Impact")]
        public string AffectedEnvImpact { get; set; }
        [Column("Affected_Env_Url")]
        public string AffectedEnvUrl { get; set; }
        public string Categories { get; set; }
        [Column("Web_Server")]
        public string WebServer { get; set; }
        [Column("Infrastructure_Type")]
        public string InfrastructureType { get; set; }
        public string Browser { get; set; }
        public string Language { get; set; }
        [Column("Root_Cause")]
        public string RootCause { get; set; }
        [Column("Resolved_By")]
        public string ResolvedBy { get; set; }
        [Column("Queue_Weight")]
        public string QueueWeight { get; set; }
        [Column("Resolution_Time_Days")]
        public decimal? ResolutionTimeDays { get; set; }
        [Column("Resolution_Time_Bucket")]
        public string ResolutionTimeBucket { get; set; }
        [Column("Hide_From_Customer")]
        public string HideFromCustomer { get; set; }
        public string Contact { get; set; }
        [Column("ContactEmployerType")]
        public string ContactEmployerType { get; set; }
        [Column("ContactEmployerType_V2")]
        public string ContactEmployerTypeV2 { get; set; }
        [Column("ContactEmployerType_V3")]
        public string ContactEmployerTypeV3 { get; set; }
        [Column("Contact_Office")]
        public string ContactOffice { get; set; }
        [Column("Preferred_Timezone")]
        public string PreferredTimezone { get; set; }
        [Column("Partner_Name")]
        public string PartnerName { get; set; }
        [Column("Partner_Country")]
        public string PartnerCountry { get; set; }
        [Column("Partner_Timezone")]
        public string PartnerTimezone { get; set; }
        [Column("Partner_Owner")]
        public string PartnerOwner { get; set; }
        [Column("Partner_Csm")]
        public string PartnerCsm { get; set; }
        [Column("Partner_Sf_Id")]
        public string PartnerSfId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerTimezone { get; set; }
        public string CustomerOwner { get; set; }
        public string CustomerCsm { get; set; }
        public string CustomerSfId { get; set; }
        public string ParentCustomerName { get; set; }
        public string ParentCustomerCountry { get; set; }
        public string ParentCustomerTimezone { get; set; }
        public string ParentCustomerOwner { get; set; }
        public string ParentCustomerCsm { get; set; }
        public string ParentCustomerSfId { get; set; }
        public string CustomerLicenseId { get; set; }
        public string CustomerSupportPlan { get; set; }
        public decimal? MetricWaitSupport { get; set; }
        public decimal? MetricWaitCloud { get; set; }
        public decimal? MetricWaitProduct { get; set; }
        public decimal? MetricWaitCustomer { get; set; }
        public int? MetricRelationsJiraCount { get; set; }
        public int? MetricRelationsDevopsCount { get; set; }
        public int? MetricRelationsChildCount { get; set; }
        [Column("Date_Created")]
        public DateTime DateCreated { get; set; }
        public int? DateCreatedDay { get; set; }
        public int? DateCreatedWeek { get; set; }
        public int? DateCreatedMonth { get; set; }
        public int? DateCreatedQuarter { get; set; }
        [Column("Date_Updated")]
        public DateTime DateUpdated { get; set; }
        public int? DateUpdatedDay { get; set; }
        public int? DateUpdatedWeek { get; set; }
        public int? DateUpdatedMonth { get; set; }
        public int? DateUpdatedQuarter { get; set; }

        [Column("Date_Resolved")]
        public DateTime DateResolved { get; set; }
        public int? DateResolvedDay { get; set; }
        public int? DateResolvedWeek { get; set; }
        public int? DateResolvedMonth { get; set; }
        public int? DateResolvedQuarter { get; set; }
        [Column("Date_Closed")]
        public DateTime DateClosed { get; set; }
        public int? DateClosedDay { get; set; }
        public int? DateClosedWeek { get; set; }
        public int? DateClosedMonth { get; set; }
        public int? DateClosedQuarter { get; set; }
        public DateTime DateEscalated { get; set; }
        public int? DateEscalatedDay { get; set; }
        public int? DateEscalatedWeek { get; set; }
        public int? DateEscalatedMonth { get; set; }
        public int? DateEscalatedQuarter { get; set; }
        public DateTime? DateSurveyExpiration { get; set; }
        public int? DateSurveyExpirationDay { get; set; }
        public int? DateSurveyExpirationWeek { get; set; }
        public int? DateSurveyExpirationMonth { get; set; }
        public int? DateSurveyExpirationQuarter { get; set; }
        public DateTime? DateSurveyCompleted { get; set; }
        public int? DateSurveyCompletedDay { get; set; }
        public int? DateSurveyCompletedWeek { get; set; }
        public int? DateSurveyCompletedMonth { get; set; }
        public int? DateSurveyCompletedQuarter { get; set; }
        public string SurveyGeneral { get; set; }
        public string SurveyResolution { get; set; }
        public string SurveyKnowledge { get; set; }
        public string SurveySpeed { get; set; }
        public string SurveyRecommend { get; set; }
        public string SurveyComment { get; set; }
        public string SurveyEvaluation { get; set; }
        public string SurveyActionsTaken { get; set; }
        public string SurveyRootCauseCode { get; set; }
    }
}
