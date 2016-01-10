using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FunctionalDashboardRestful.Models;
using FunctionalDashboardRestful.DTO;
using System.IO;

namespace FunctionalDashboardRestful.Controllers
{
    public class TL_EventLogController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();



        // GET: api/TL_EventLog
        [CacheClient(Duration = 120)]
        public IQueryable<OverviewErrorsDto> GetTL_EventLog()
        {
            // below two are equivalent 
#if false 
            var entries = from ev in db.TL_EventLog                        
                          where ev.Level == EVENT_STATUS.ERROR || ev.Level == EVENT_STATUS.WARNING
                          group ev by new { ev.ProgramID, ev.InstitutionID } into g
                          select new OverviewErrorsDto
                          {
                
                              OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int) n.OrganizationId).FirstOrDefault(), 
                              Program = g.Key.ProgramID,
                              Institution = g.Key.InstitutionID,
                              FileErrors = g.Where(x => x.URIType == "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                              WSErrors = g.Where(x => x.URIType != "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                              Active = (bool)(from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Active).FirstOrDefault()
                          };
            return entries;

#else
            var entries = db.TL_EventLog
                .Where(x => x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)
                .GroupBy(x => new { x.ProgramID, x.InstitutionID, x.Category })
                .Select(g => new OverviewErrorsDto
                {
                    DateStart = g.FirstOrDefault().ProcessDatetime,
                    OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                    Program = g.Key.ProgramID,
                    InstitutionID = g.Key.InstitutionID,
                    Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.ShortName).FirstOrDefault(),
                    Category = g.Key.Category,
                    CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.Key.Category select e.CategoryID).FirstOrDefault(),
                    EventID = (int)g.FirstOrDefault().EventID,
                    Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                    Requests = g.Where(r => r.RequestTxID != null).Count(),
                    URI = g.FirstOrDefault().URI,
                    GUID = g.FirstOrDefault().GUID,
                    FileErrors = g.Where(x => x.URIType == "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                    WSErrors = g.Where(x => x.URIType != "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                    Active = (bool)(from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Active).FirstOrDefault()
                });

            return entries;
#endif
        }

        // GET: api/TL_EventLog
        [CacheClient(Duration = 120)]
        public IQueryable<OverviewErrorsDto> GetTL_EventLog(DateTime start, DateTime end)
        {
            var entries = db.TL_EventLog
                .Where(x => x.ProcessDatetime >= start &&
                       x.ProcessDatetime <= end &&
                       (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING))
                .GroupBy(x => new { x.ProgramID, x.InstitutionID, x.Category })
                .Select(g => new OverviewErrorsDto
                {
                    DateStart = g.FirstOrDefault().ProcessDatetime,
                    OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                    Program = g.Key.ProgramID,
                    InstitutionID = g.Key.InstitutionID,
                    Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                    Category = g.Key.Category,
                    CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.Key.Category select e.CategoryID).FirstOrDefault(),
                    EventID = (int)g.FirstOrDefault().EventID,
                    Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                    Requests = g.Where(r => r.RequestTxID != null).Count(),
                    URI = g.FirstOrDefault().URI,
                    GUID = g.FirstOrDefault().GUID,
                    FileErrors = g.Where(x => x.URIType == "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                    WSErrors = g.Where(x => x.URIType != "sFTP" && (x.Level == EVENT_STATUS.ERROR || x.Level == EVENT_STATUS.WARNING)).Count(),
                    Active = (bool)(from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Active).FirstOrDefault()
                });

            return entries;
        }

        [CacheClient(Duration = 120)]
        public IQueryable<BaseDto> GetTL_EventLog(DateTime start, DateTime end, TABLE_SEQUENCE sequence, string institutionID, string uri)
        {
            if (sequence == TABLE_SEQUENCE.FILES_PPASS)
            {
                var entries = db.TL_EventLog
                    .Where(x => x.ProcessDatetime >= start &&
                           x.ProcessDatetime <= end &&
                           x.InstitutionID != null &&
                           x.ProgramID == PROGRAM_ID.PPASS &&
                           x.URIType == "sFTP")
                    .GroupBy(x => new { x.ProgramID, x.InstitutionID })
                    .Select(g => new FilesDto
                    {
                        ID = g.FirstOrDefault().ID,
                        DateStart = g.FirstOrDefault().ProcessDatetime,
                        OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                        NCSName = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        NCSCustomerAssignedID = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.ShortName).FirstOrDefault(),

                        Program = g.Key.ProgramID,
                        InstitutionID = g.Key.InstitutionID,
                        Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        Category = g.FirstOrDefault().Category,
                        CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                        EventID = (int)g.FirstOrDefault().EventID,
                        Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                        Requests = g.Where(r => r.UniqueParticipantId != null).Count(),
                        Uri = g.FirstOrDefault().URI,
                        IufRequests = g.Where(r => r.RequestTxID != null && r.Category == CATEGORY_ID_FILES.IUF).Count(),
                        FufRequests = g.Where(r => r.RequestTxID != null && r.Category == CATEGORY_ID_FILES.FUF).Count(),
                        FcfRequests = g.Where(r => r.RequestTxID != null && r.Category == CATEGORY_ID_FILES.FCF).Count(),
                        IcfRequests = g.Where(r => r.RequestTxID != null && r.Category == CATEGORY_ID_FILES.ICF).Count(),
                        TotalErrors = g.Where(e => e.Level == EVENT_STATUS.ERROR).Count(),
                    });
                return entries;
            }
            else if (sequence == TABLE_SEQUENCE.FILES_UPASS)
            {
                var entries = db.TL_EventLog
                    .Where(x => x.ProcessDatetime >= start &&
                           x.ProcessDatetime <= end &&
                           x.InstitutionID != null &&
                           x.ProgramID == PROGRAM_ID.UPASS &&
                           x.URIType == "sFTP")
                    .GroupBy(x => new { x.ProgramID, x.InstitutionID })
                    .Select(g => new FilesDto
                    {
                        DateStart = g.FirstOrDefault().ProcessDatetime,
                        OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                        NCSName = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        NCSCustomerAssignedID = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.ShortName).FirstOrDefault(),
                        Program = g.Key.ProgramID,
                        InstitutionID = g.Key.InstitutionID,
                        Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        Category = g.FirstOrDefault().Category,
                        CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                        EventID = (int)g.FirstOrDefault().EventID,
                        Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                        Requests = g.Where(r => r.UniqueParticipantId != null).Count(),
                        TotalErrors = g.Where(e => e.Level == EVENT_STATUS.ERROR).Count()
                    });
                return entries;
            }
            else if (sequence == TABLE_SEQUENCE.FILES_CURRENT_FILE_STREAM)
            {
                var entries = db.TL_EventLog
                    .Where(x => x.ProcessDatetime >= start &&
                           x.ProcessDatetime <= end &&
                           x.InstitutionID != null &&
                           (x.URI.ToUpper().Contains("IUF_") ||
                            x.URI.ToUpper().Contains("ICF_") ||
                            x.URI.ToUpper().Contains("FUF_") ||
                            x.URI.ToUpper().Contains("FCF_") ||
                            x.URI.Contains(PROGRAM_ID.UPASS)))
                    .GroupBy(x => new { x.ProgramID, x.InstitutionID, x.Category, x.EventID })
                    .Select(g => new FilesDto
                    {
                        ID = g.FirstOrDefault().ID,
                        DateStart = g.FirstOrDefault().ProcessDatetime,
                        OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                        NCSName = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        NCSCustomerAssignedID = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.ShortName).FirstOrDefault(),
                        Program = g.Key.ProgramID,
                        InstitutionID = g.Key.InstitutionID,
                        Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        Category = g.Key.Category,
                        CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                        EventID = (int)g.Key.EventID,
                        Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                        Requests = g.Where(r => r.RequestTxID != null || r.UniqueParticipantId != null).Count(),
                        Uri = g.FirstOrDefault().URI,
                        RequestTxID = g.FirstOrDefault().RequestTxID,
                        UniqueParticipantId = g.FirstOrDefault().UniqueParticipantId,
                        Action = g.FirstOrDefault().Action,
                        ReasonCode = g.FirstOrDefault().ReasonCode,
                        TotalErrors = g.Where(e => e.Level == EVENT_STATUS.ERROR).Count(),
                        XmlData = g.FirstOrDefault().XmlData

                    });
                return entries;
            }

            else if (sequence == TABLE_SEQUENCE.CUBICWS_PPASS)
            {
                var entries = db.TL_EventLog
                    .Where(x => x.ProcessDatetime >= start &&
                           x.ProcessDatetime <= end &&
                           x.InstitutionID != null &&
                           x.ProgramID == PROGRAM_ID.PPASS &&
                           x.URIType == "API")
                    .GroupBy(x => new { x.ProgramID, x.InstitutionID })
                    .Select(g => new CubicwsDto
                    {
                        TaskID = g.FirstOrDefault().TaskID,
                        StateID = g.FirstOrDefault().StateID,
                        DateStart = g.FirstOrDefault().ProcessDatetime,
                        OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                        Program = g.Key.ProgramID,
                        InstitutionID = g.Key.InstitutionID,
                        Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        Category = g.FirstOrDefault().Category,
                        CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                        EventID = (int)g.FirstOrDefault().EventID,
                        Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                        CardSerialNumber = g.FirstOrDefault().CardSerialNumber,
                        NewCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.NEW_CARD).Count(),
                        TerminateCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.TERMINATE_CARD).Count(),
                        ReplacementCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.REPLACEMENT_CARD).Count(),
                        SuspendCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.SUSPEND_CARD).Count(),
                        ResumeCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.REPLACEMENT_CARD).Count(),
                        TotalErrors = g.Where(e => e.Level == EVENT_STATUS.ERROR || e.Level == EVENT_STATUS.WARNING).Count(),
                        Level = g.FirstOrDefault().Level,
                        ProcessErrorID = g.FirstOrDefault().ProcessErrorID,
                        XmlData = g.FirstOrDefault().XmlData
                    });
                return entries;
            }
            else if (sequence == TABLE_SEQUENCE.CUBICWS_UPASS)
            {
                var entries = db.TL_EventLog
                    .Where(x => x.ProcessDatetime >= start &&
                           x.ProcessDatetime <= end &&
                           //x.InstitutionID != null &&
                           x.ProgramID == PROGRAM_ID.UPASS &&
                   (x.URIType == "API" || x.URIType == "NoURI" || x.URIType == "Webservice"))
                    .GroupBy(x => new { x.ProgramID, x.InstitutionID })
                    .Select(g => new CubicwsDto
                    {
                        TaskID = g.FirstOrDefault().TaskID,
                        StateID = g.FirstOrDefault().StateID,
                        DateStart = g.FirstOrDefault().ProcessDatetime,
                        OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                        Program = g.Key.ProgramID,
                        InstitutionID = g.Key.InstitutionID,
                        Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                        Category = g.FirstOrDefault().Category,
                        CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                        EventID = (int)g.FirstOrDefault().EventID,
                        Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                        WaiveBenefits = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.WAIVE_BENEFIT).Count(),
                        ElectBenefits = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.ELECT_BENEFIT).Count(),
                        LinkCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.LINK_CARD).Count(),
                        UnlinkCards = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.UNLINK_CARD).Count(),
                        UpassWebServices = g.Where(c => c.Category == CATEGORY_ID_WEBSERVICES.WEB_SERVICES).Count(),
                        Others = g.Where(c => !(c.Category == CATEGORY_ID_WEBSERVICES.WAIVE_BENEFIT ||
                                                c.Category == CATEGORY_ID_WEBSERVICES.ELECT_BENEFIT ||
                                                c.Category == CATEGORY_ID_WEBSERVICES.LINK_CARD ||
                                                c.Category == CATEGORY_ID_WEBSERVICES.UNLINK_CARD ||
                                                c.Category == CATEGORY_ID_WEBSERVICES.WEB_SERVICES)).Count(),
                        TotalErrors = g.Where(e => e.Level == EVENT_STATUS.ERROR || e.Level == EVENT_STATUS.WARNING).Count(),
                        Level = g.FirstOrDefault().Level,
                        ProcessErrorID = g.FirstOrDefault().ProcessErrorID,
                        XmlData = g.FirstOrDefault().XmlData
                    });
                return entries;
            }
            else if (sequence == TABLE_SEQUENCE.CUBICWS_CURRENT_WEBSERVICE_STREAM)
            {
                var entries = db.TL_EventLog
                .Where(x => x.ProcessDatetime >= start &&
                       x.ProcessDatetime <= end &&
                       //x.InstitutionID != null &&
                       x.URIType != "sFTP")
                .GroupBy(x => new { x.ProgramID, x.InstitutionID, x.Category, x.GUID })
                .Select(g => new CubicwsDto
                {
                    ID = g.FirstOrDefault().ID,
                    TaskID = g.FirstOrDefault().TaskID,
                    StateID = g.FirstOrDefault().StateID,
                    DateStart = g.FirstOrDefault().ProcessDatetime,
                    OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select (int)n.OrganizationId).FirstOrDefault(),
                    NCSName = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                    Program = g.Key.ProgramID,
                    InstitutionID = g.Key.InstitutionID,
                    Institution = (from n in db.NCSInfoes where n.InstitutionId == g.Key.InstitutionID select n.Name).FirstOrDefault(),
                    Category = g.FirstOrDefault().Category,
                    CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                    EventID = (int)g.FirstOrDefault().EventID,
                    Event = (from e in db.EventIDLists where e.EventID == g.FirstOrDefault().EventID select e.EventName).FirstOrDefault(),
                    Events = g.Select(e => new Event_ID
                    {
                        ID = e.ID,
                        Event = (from ev in db.EventIDLists where ev.EventID == e.EventID select ev.EventName).FirstOrDefault(),
                        Level = e.Level,
                    }).ToList(),
                    GUID = g.Key.GUID,
                    TSID = g.FirstOrDefault().TSID,
                    UniqueParticipantId = g.FirstOrDefault().UniqueParticipantId,
                    Uri = g.FirstOrDefault().URI,
                    TotalErrors = g.Where(s => s.Level == EVENT_STATUS.ERROR || s.Level == EVENT_STATUS.WARNING).Count(),
                    Level = g.FirstOrDefault().Level,
                    ProcessErrorID = g.FirstOrDefault().ProcessErrorID,
                    EligDate = g.FirstOrDefault().EligDate,
                    Elig = g.FirstOrDefault().Elig,
                    Status = g.FirstOrDefault().Rval,
                    XmlData = g.FirstOrDefault().XmlData
                });
                return entries;
            }
            else if (sequence == TABLE_SEQUENCE.FILES_DETAIL)
            {
                var entries = db.TL_EventLog
                .Where(x => x.ProcessDatetime >= start &&
                       x.ProcessDatetime <= end &&
                       x.InstitutionID != null &&
                       x.InstitutionID == institutionID &&
                       x.URI.Contains(uri) &&
                       x.URIType == "sFTP")
                .GroupBy(x => new { x.RequestTxID, x.EventID })
                .Select(g => new FilesDto
                {
                    ID = g.FirstOrDefault().ID,
                    TaskID = g.FirstOrDefault().TaskID,
                    StateID = g.FirstOrDefault().StateID,
                    DateStart = g.FirstOrDefault().ProcessDatetime,
                    OrganizationId = (from n in db.NCSInfoes where n.InstitutionId == institutionID select (int)n.OrganizationId).FirstOrDefault(),
                    NCSName = (from n in db.NCSInfoes where n.InstitutionId == institutionID select n.Name).FirstOrDefault(),
                    NCSCustomerAssignedID = (from n in db.NCSInfoes where n.InstitutionId == institutionID select n.ShortName).FirstOrDefault(),
                    Program = g.FirstOrDefault().ProgramID,
                    InstitutionID = institutionID,
                    Institution = (from n in db.NCSInfoes where n.InstitutionId == institutionID select n.Name).FirstOrDefault(),
                    EventID = (int)g.Key.EventID,
                    Event = (from e in db.EventIDLists where e.EventID == g.Key.EventID select e.EventName).FirstOrDefault(),
                    Category = g.FirstOrDefault().Category,
                    CategoryID = (from e in db.CategoryIDLists where e.CategoryName == g.FirstOrDefault().Category select e.CategoryID).FirstOrDefault(),
                    Uri = g.FirstOrDefault().URI,
                    UniqueParticipantId = g.FirstOrDefault().UniqueParticipantId,
                    RequestTxID = g.Key.RequestTxID,
                    Action = g.FirstOrDefault().Action,
                    ReasonCode = g.FirstOrDefault().ReasonCode,
                    CardSerialNumber = g.FirstOrDefault().CardSerialNumber,
                    Errors = g.Where(e => e.Level == EVENT_STATUS.ERROR).Count(),
                    XmlData = g.FirstOrDefault().XmlData
                });

                return entries;
            }
            else
            {
                return null;
            }
        }

        // GET: api/TL_EventLog/5
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> GetTL_EventLog(long id)
        {
            TL_EventLog tL_EventLog = await db.TL_EventLog.FindAsync(id);
            if (tL_EventLog == null)
            {
                return NotFound();
            }

            return Ok(tL_EventLog);
        }

        // PUT: api/TL_EventLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTL_EventLog(long id, TL_EventLog tL_EventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tL_EventLog.ID)
            {
                return BadRequest();
            }

            db.Entry(tL_EventLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TL_EventLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TL_EventLog
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> PostTL_EventLog(TL_EventLog tL_EventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TL_EventLog.Add(tL_EventLog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tL_EventLog.ID }, tL_EventLog);
        }

        // DELETE: api/TL_EventLog/5
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> DeleteTL_EventLog(long id)
        {
            TL_EventLog tL_EventLog = await db.TL_EventLog.FindAsync(id);
            if (tL_EventLog == null)
            {
                return NotFound();
            }

            db.TL_EventLog.Remove(tL_EventLog);
            await db.SaveChangesAsync();

            return Ok(tL_EventLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TL_EventLogExists(long id)
        {
            return db.TL_EventLog.Count(e => e.ID == id) > 0;
        }
    }
}