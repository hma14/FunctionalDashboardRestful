using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.DTO
{
    public class CubicwsDto : BaseDto
    {
        public string NCSName { get; set; }        
        public int NewCards { get; set; }
        public int TerminateCards { get; set; }
        public int ReplacementCards { get; set; }
        public int SuspendCards { get; set; }
        public int ResumeCards { get; set; }

        public int WaiveBenefits { get; set; }
        public int ElectBenefits { get; set; }
        public int LinkCards { get; set; }
        public int UnlinkCards { get; set; }
        public int UpassWebServices { get; set; }
        public int Others { get; set; }
        public string GUID { get; set; }
        public string TSID { get; set; }
        public string UniqueParticipantId { get; set; }
        public string Uri { get; set; }
        public List<Event_ID> Events { get; set; }
        public string CardSerialNumber { get; set; }
        public string ProcessErrorID { get; set; }
        public string EligDate { get; set; }
        public string Elig { get; set; }
        public string Status { get; set; }

    }

    public class Event_ID
    {
        public long ID { get; set; }
        public string Event { get; set; }
        public string Level { get; set; }

    }
}