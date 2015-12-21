using System.Data.Entity;
using System.Data.Entity.Infrastructure;
//using FunctionalDashboardRestful.Models.Mapping;

namespace FunctionalDashboardRestful.Models
{
    public partial class UPASSDASHDEVContext : DbContext
    {
        static UPASSDASHDEVContext()
        {
            Database.SetInitializer<UPASSDASHDEVContext>(null);
        }

        public UPASSDASHDEVContext()
            : base("Name=UPASSDASHDEVContext")
        {
        }

        public DbSet<CPGFD_ErrorExceptions> CPGFD_ErrorExceptions { get; set; }
        public DbSet<CPGFD_ErrorList> CPGFD_ErrorList { get; set; }
        public DbSet<CPGFD_ErrorMsg> CPGFD_ErrorMsg { get; set; }
        public DbSet<CPGFD_KB> CPGFD_KB { get; set; }
        public DbSet<CPGFD_Roles> CPGFD_Roles { get; set; }
        public DbSet<CPGFD_SLTRules> CPGFD_SLTRules { get; set; }
        public DbSet<CPGFD_SLTTracking> CPGFD_SLTTracking { get; set; }
        public DbSet<CPGFD_Users> CPGFD_Users { get; set; }
        public DbSet<CPGFD_UsersInRoles> CPGFD_UsersInRoles { get; set; }
        public DbSet<EventIDList> EventIDLists { get; set; }
        public DbSet<NCSInfo> NCSInfoes { get; set; }
        public DbSet<SLTTrackingHistory> SLTTrackingHistories { get; set; }
        public DbSet<TL_EventLog> TL_EventLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CPGFD_ErrorExceptionsMap());
            //modelBuilder.Configurations.Add(new CPGFD_ErrorListMap());
            //modelBuilder.Configurations.Add(new CPGFD_ErrorMsgMap());
            //modelBuilder.Configurations.Add(new CPGFD_KBMap());
            //modelBuilder.Configurations.Add(new CPGFD_RolesMap());
            //modelBuilder.Configurations.Add(new CPGFD_SLTRulesMap());
            //modelBuilder.Configurations.Add(new CPGFD_SLTTrackingMap());
            //modelBuilder.Configurations.Add(new CPGFD_UsersMap());
            //modelBuilder.Configurations.Add(new CPGFD_UsersInRolesMap());
            //modelBuilder.Configurations.Add(new EventIDListMap());
            //modelBuilder.Configurations.Add(new NCSInfoMap());
            //modelBuilder.Configurations.Add(new SLTTrackingHistoryMap());
            //modelBuilder.Configurations.Add(new TL_EventLogMap());
        }
    }
}
