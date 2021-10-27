using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.DbModels
{
    [Table("PublicCases")]
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
        public string IdSys { get; set; }
        public string IdOld { get; set; }
        public string State { get; set; }
        public string Stage { get; set; }
        public string ShortDescription { get; set; }
        public string InvestigationScope { get; set; }
        public string Priority { get; set; }
        public string AssignedTo { get; set; }
        public string AssignmentGroup { get; set; }
        public string AssignmentGroupV2 { get; set; }
        public string AssignmentGroupV3 { get; set; }
        public string AssignmentGroupV4 { get; set; }
        public string AssignmentGroupInitial { get; set; }
        public string AssignmentGroupRegion { get; set; }
        public string AssignmentGroupResolutionOwner { get; set; }
        public string AssignmentGroupTriageOwner { get; set; }
        public string SupportLevel { get; set; }
        public string AffectedSoftware { get; set; }
        public string Product { get; set; }
        public string ProductVersion { get; set; }
        public string ProductV2 { get; set; }
        public string ProductV3 { get; set; }
        public string ProductV4 { get; set; }
        public string Module { get; set; }
        public string ModuleVersion { get; set; }
        public string ScFollowTheSun { get; set; }
        public string EscalationState { get; set; }
        public string EscalatedBy { get; set; }
        public decimal? TotalTimeWorked { get; set; }
        public string TotalTimeWorkedBucket { get; set; }
        public string Type { get; set; }
        public string AffectedEnvType { get; set; }
        public string AffectedEnvImpact { get; set; }
        public string AffectedEnvUrl { get; set; }
        public string Categories { get; set; }
        public string WebServer { get; set; }
        public string InfrastructureType { get; set; }
        public string Browser { get; set; }
        public string Language { get; set; }
        public string RootCause { get; set; }
        public string ResolvedBy { get; set; }
        public string QueueWeight { get; set; }
        public decimal? ResolutionTimeDays { get; set; }
        public string ResolutionTimeBucket { get; set; }
        public string HideFromCustomer { get; set; }
        public string Contact { get; set; }
        public string ContactEmployerType { get; set; }
        public string ContactEmployerTypeV2 { get; set; }
        public string ContactEmployerTypeV3 { get; set; }
        public string ContactOffice { get; set; }
        public string PreferredTimezone { get; set; }
        public string PartnerName { get; set; }
        public string PartnerCountry { get; set; }
        public string PartnerTimezone { get; set; }
        public string PartnerOwner { get; set; }
        public string PartnerCsm { get; set; }
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
        public DateTime DateCreated { get; set; }
        public int? DateCreatedDay { get; set; }
        public int? DateCreatedWeek { get; set; }
        public int? DateCreatedMonth { get; set; }
        public int? DateCreatedQuarter { get; set; }
        public DateTime DateUpdated { get; set; }
        public int? DateUpdatedDay { get; set; }
        public int? DateUpdatedWeek { get; set; }
        public int? DateUpdatedMonth { get; set; }
        public int? DateUpdatedQuarter { get; set; }
        public DateTime DateResolved { get; set; }
        public int? DateResolvedDay { get; set; }
        public int? DateResolvedWeek { get; set; }
        public int? DateResolvedMonth { get; set; }
        public int? DateResolvedQuarter { get; set; }
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
