using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
