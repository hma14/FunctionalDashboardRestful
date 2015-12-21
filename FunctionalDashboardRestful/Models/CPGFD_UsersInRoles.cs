using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_UsersInRoles
    {
        [Key]
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }
}
