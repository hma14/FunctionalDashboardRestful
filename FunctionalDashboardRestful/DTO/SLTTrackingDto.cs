using FunctionalDashboardRestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.DTO
{
    public class SLTTrackingDto
    {
        public int EventID { get; set; }
        public string Event { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public string ProgramID { get; set; }
        public string InstitutionID { get; set; }
        public string Institution { get; set; }
        public string RuleDescription { get; set; }
        public Nullable<System.DateTime> SLTWarningDatetime { get; set; }
        public Nullable<System.DateTime> SLTBreachDatetime { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}