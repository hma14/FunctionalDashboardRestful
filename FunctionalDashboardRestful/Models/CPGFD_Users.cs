using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FunctionalDashboardRestful.Models
{
    public partial class CPGFD_Users
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
