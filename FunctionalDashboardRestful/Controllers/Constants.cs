using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunctionalDashboardRestful.Controllers
{
    public class EVENT_STATUS
    {
        public static string COMPLETED = "Information";
        public static string ERROR = "Error";
        public static string CLEARED = "Cleared";
        public static string ACKNOWLEDGED = "Acknowledged";
        public static string WARNING = "Warning";
        public static string SUPPRESSION = "Suppression";
    }

    public class PROGRAM_ID
    {
        public static readonly string UPASS = "UPASS";
        public static readonly string PPASS = "PPASS";
    }

    public class CATEGORY_ID_FILES
    {
        public const string FUF = "FUF";
        public const string ICF = "ICF";
        public const string FCF = "FCF";
        public const string IUF = "IUF";

    }

    public class CATEGORY_ID_WEBSERVICES
    {
        // PPASS
        public const string NEW_CARD = "PpassNewCard";
        public const string TERMINATE_CARD = "PpassTerminatedCard";
        public const string REPLACEMENT_CARD = "PpassReplacementCard";
        public const string SUSPEND_CARD = "PpassSuspendCard";
        public const string RESUME_CARD = "PpassResumeCard";

        // UPASS
        public const string WAIVE_BENEFIT = "UpassWaiveBenefitTask";
        public const string ELECT_BENEFIT = "UpassElectBenefitTask";
        public const string LINK_CARD = "UpassLinkCardTask";
        public const string UNLINK_CARD = "UpassUnLinkCardTask";
        public const string WEB_SERVICES = "UpassWebServices";
        public const string REQUEST_FILE = "UpassRequestFile";
        public const string RESPONSE_FILE = "UpassResponseFile";
        public const string ELIGIBILITY_STATUS = "UpassEligibilityStatus";

    }

    public enum TABLE_SEQUENCE
    {
            FILES_PPASS = 1,
            FILES_UPASS = 2,
            FILES_CURRENT_FILE_STREAM = 3,
            CUBICWS_PPASS = 4,
            CUBICWS_UPASS = 5,
            CUBICWS_CURRENT_WEBSERVICE_STREAM = 6,
            FILES_DETAIL = 7
    }
}