using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_ErrorMsg
    {
        [Key]
        public int ID { get; set; }
        public Nullable<int> ErrorListID { get; set; }
        public string Message { get; set; }
        public Nullable<byte> Status { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDatetime { get; set; }
        public virtual CPGFD_ErrorList CPGFD_ErrorList { get; set; }
    }
}
