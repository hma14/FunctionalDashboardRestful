using System;
using System.Collections.Generic;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_KB
    {
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Description { get; set; }
        public string PotentialErrors { get; set; }
        public string BusinessImpact { get; set; }
        public Nullable<byte> Sev { get; set; }
        public string Resolutions { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDatetime { get; set; }
    }
}
