using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class SLTTrackingHistory
    {
        [Key]
        public int ID { get; set; }
        public int SLTTrackingID { get; set; }
        public string Message { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDatetime { get; set; }
    }
}
