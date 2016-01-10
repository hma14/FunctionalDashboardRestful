using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.DTO
{
    public class BaseDto
    {
        public long ID { get; set; }
        public int? TaskID { get; set; }
        public int? StateID { get; set; }
        public string Level { get; set; }
        public DateTime DateStart { get; set; }
        public int OrganizationId { get; set; }
        public string Program { get; set; }
        public string InstitutionID { get; set; }
        public string Institution { get; set; }
        public string Category { get; set; }
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        public string Event { get; set; }
        public int TotalErrors { get; set; }

        public string XmlData { get; set; }
    }
}