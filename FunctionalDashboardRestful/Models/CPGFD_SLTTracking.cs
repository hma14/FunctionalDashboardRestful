using System;
using System.Collections.Generic;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_SLTTracking
    {
        public long ID { get; set; }
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public string ProgramID { get; set; }
        public string InstitutionID { get; set; }
        public Nullable<int> SLTRuleID { get; set; }
        public string RuleDescription { get; set; }
        public Nullable<System.DateTime> SLTStartDatetime { get; set; }
        public Nullable<System.DateTime> SLTWarningDatetime { get; set; }
        public Nullable<System.DateTime> SLTBreachDatetime { get; set; }
        public Nullable<System.DateTime> SLTCompleteDatetime { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<System.DateTime> UpdatedDatetime { get; set; }
        public string UpdatedUser { get; set; }
        public virtual CPGFD_SLTRules CPGFD_SLTRules { get; set; }
    }
}
