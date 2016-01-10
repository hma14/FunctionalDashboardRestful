using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.DTO
{
    public class FilesDto : BaseDto
    {
        public string NCSName { get; set; }
        public string NCSCustomerAssignedID { get; set; }
        public int IufRequests { get; set; }
        public int FufRequests { get; set; }
        public int FcfRequests { get; set; }
        public int IcfRequests { get; set; }
        public int Requests { get; set; }
        public string Uri { get; set; }
        public string FileName { get; set; }
        public string Directory { get; set; }
        public string RequestTxID { get; set; }
        public string UniqueParticipantId { get; set; }
        public string CardSerialNumber { get; set; }
        public string Action { get; set; }
        public string ReasonCode { get; set; }
        public int Errors { get; set; }
    }
}