using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class TL_EventLog
    {
        [Key]
        public long ID { get; set; }
        public long SourceLogID { get; set; }
        public string LogName { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public Nullable<int> EventID { get; set; }
        public string Computer { get; set; }
        public System.DateTime LoggedTime { get; set; }
        public string ProgramID { get; set; }
        public string InstitutionID { get; set; }
        public string UploadFileName { get; set; }
        public string FileStatus { get; set; }
        public string RequestTxID { get; set; }
        public string GUID { get; set; }
        public Nullable<int> TaskID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string UniqueParticipantId { get; set; }
        public string CardSerialNumber { get; set; }
        public string ExistingCardSN { get; set; }
        public string Action { get; set; }
        public string ReasonCode { get; set; }
        public string Benefit { get; set; }
        public string CardTypeCode { get; set; }
        public string SuccessFailureCode { get; set; }
        public string SuccessFailureDescr { get; set; }
        public string ActionExecuted { get; set; }
        public string TSID { get; set; }
        public string Elig { get; set; }
        public string EligDate { get; set; }
        public string Rval { get; set; }
        public string Rext { get; set; }
        public Nullable<int> BenefitID { get; set; }
        public Nullable<long> BenefitProductID { get; set; }
        public Nullable<int> BenefitMonth { get; set; }
        public Nullable<int> BenefitYear { get; set; }
        public string URI { get; set; }
        public string URIType { get; set; }
        public System.DateTime ProcessDatetime { get; set; }
        public string ProcessErrorID { get; set; }
        public string XmlData { get; set; }
    }
}
