using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class EventIDList
    {
        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
    }
}
