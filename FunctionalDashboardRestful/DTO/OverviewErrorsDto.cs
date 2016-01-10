using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.DTO
{
    public class OverviewErrorsDto : BaseDto
    {
      
        public int FileErrors { get; set; }
        public int WSErrors { get; set; }
        public bool Active { get; set; }

        public string URI { get; set; }

        public string GUID { get; set; }

        public int Requests { get; set; }

    }
   
}