using System;
using System.Collections.Generic;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_SLTRules
    {
        public CPGFD_SLTRules()
        {
            this.CPGFD_SLTTracking = new List<CPGFD_SLTTracking>();
        }

        public int ID { get; set; }
        public string ProgramID { get; set; }
        public string InstitutionID { get; set; }
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        public byte RuleType { get; set; }
        public Nullable<byte> DayOfWeek { get; set; }
        public Nullable<int> RuleDay { get; set; }
        public Nullable<System.DateTime> RuleTime { get; set; }
        public Nullable<int> WarningThreshold { get; set; }
        public byte Status { get; set; }
        public Nullable<System.DateTime> NextTriggerDatetime { get; set; }
        public System.DateTime UpdatedDatetime { get; set; }
        public string UpdatedUser { get; set; }
        public string RuleDescription { get; set; }
        public virtual ICollection<CPGFD_SLTTracking> CPGFD_SLTTracking { get; set; }
    }
}
