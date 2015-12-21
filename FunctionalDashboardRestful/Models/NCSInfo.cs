using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class NCSInfo
    {
        public Nullable<int> OrganizationId { get; set; }
        [Key]
        public string InstitutionId { get; set; }
        public string ProgramId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
