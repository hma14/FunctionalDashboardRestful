using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_ErrorList
    {
        public CPGFD_ErrorList()
        {
            this.CPGFD_ErrorMsg = new List<CPGFD_ErrorMsg>();
        }

        [Key]
        public int ID { get; set; }
        public string ProgramID { get; set; }
        public string InstitutionID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<long> ProcessDatetime { get; set; }
        public Nullable<int> Status { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDatetime { get; set; }
        public virtual ICollection<CPGFD_ErrorMsg> CPGFD_ErrorMsg { get; set; }
    }
}
