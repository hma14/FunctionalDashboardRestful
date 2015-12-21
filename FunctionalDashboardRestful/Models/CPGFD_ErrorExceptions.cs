using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_ErrorExceptions
    {
        [Key]
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
