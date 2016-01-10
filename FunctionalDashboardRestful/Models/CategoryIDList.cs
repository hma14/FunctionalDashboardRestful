using System;
using System.Collections.Generic;

namespace FunctionalDashboardRestful.Models
{
    public partial class CategoryIDList
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
    }

    public enum TRACKING_STATUS
    {
        Completed,
        Active,
        Warning,
        Breach,
        Cleared
    }
}
