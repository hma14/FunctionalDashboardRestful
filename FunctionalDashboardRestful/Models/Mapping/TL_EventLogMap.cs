using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunctionalDashboardRestful.Models.Mapping
{
    public class TL_EventLogMap : EntityTypeConfiguration<TL_EventLog>
    {
        public TL_EventLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.LogName)
                .HasMaxLength(64);

            this.Property(t => t.Level)
                .HasMaxLength(32);

            this.Property(t => t.Source)
                .HasMaxLength(196);

            this.Property(t => t.Category)
                .HasMaxLength(196);

            this.Property(t => t.Computer)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ProgramID)
                .HasMaxLength(10);

            this.Property(t => t.InstitutionID)
                .HasMaxLength(10);

            this.Property(t => t.UploadFileName)
                .HasMaxLength(900);

            this.Property(t => t.FileStatus)
                .HasMaxLength(10);

            this.Property(t => t.RequestTxID)
                .HasMaxLength(40);

            this.Property(t => t.GUID)
                .HasMaxLength(36);

            this.Property(t => t.UniqueParticipantId)
                .HasMaxLength(60);

            this.Property(t => t.CardSerialNumber)
                .HasMaxLength(20);

            this.Property(t => t.ExistingCardSN)
                .HasMaxLength(20);

            this.Property(t => t.Action)
                .HasMaxLength(2);

            this.Property(t => t.ReasonCode)
                .HasMaxLength(2);

            this.Property(t => t.Benefit)
                .HasMaxLength(50);

            this.Property(t => t.CardTypeCode)
                .HasMaxLength(10);

            this.Property(t => t.SuccessFailureCode)
                .HasMaxLength(10);

            this.Property(t => t.SuccessFailureDescr)
                .HasMaxLength(128);

            this.Property(t => t.ActionExecuted)
                .HasMaxLength(20);

            this.Property(t => t.TSID)
                .HasMaxLength(12);

            this.Property(t => t.Elig)
                .HasMaxLength(10);

            this.Property(t => t.EligDate)
                .HasMaxLength(20);

            this.Property(t => t.Rval)
                .HasMaxLength(3);

            this.Property(t => t.Rext)
                .HasMaxLength(5);

            this.Property(t => t.URI)
                .HasMaxLength(1000);

            this.Property(t => t.URIType)
                .HasMaxLength(50);

            this.Property(t => t.ProcessErrorID)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TL_EventLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SourceLogID).HasColumnName("SourceLogID");
            this.Property(t => t.LogName).HasColumnName("LogName");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.Computer).HasColumnName("Computer");
            this.Property(t => t.LoggedTime).HasColumnName("LoggedTime");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.InstitutionID).HasColumnName("InstitutionID");
            this.Property(t => t.UploadFileName).HasColumnName("UploadFileName");
            this.Property(t => t.FileStatus).HasColumnName("FileStatus");
            this.Property(t => t.RequestTxID).HasColumnName("RequestTxID");
            this.Property(t => t.GUID).HasColumnName("GUID");
            this.Property(t => t.TaskID).HasColumnName("TaskID");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.UniqueParticipantId).HasColumnName("UniqueParticipantId");
            this.Property(t => t.CardSerialNumber).HasColumnName("CardSerialNumber");
            this.Property(t => t.ExistingCardSN).HasColumnName("ExistingCardSN");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ReasonCode).HasColumnName("ReasonCode");
            this.Property(t => t.Benefit).HasColumnName("Benefit");
            this.Property(t => t.CardTypeCode).HasColumnName("CardTypeCode");
            this.Property(t => t.SuccessFailureCode).HasColumnName("SuccessFailureCode");
            this.Property(t => t.SuccessFailureDescr).HasColumnName("SuccessFailureDescr");
            this.Property(t => t.ActionExecuted).HasColumnName("ActionExecuted");
            this.Property(t => t.TSID).HasColumnName("TSID");
            this.Property(t => t.Elig).HasColumnName("Elig");
            this.Property(t => t.EligDate).HasColumnName("EligDate");
            this.Property(t => t.Rval).HasColumnName("Rval");
            this.Property(t => t.Rext).HasColumnName("Rext");
            this.Property(t => t.BenefitID).HasColumnName("BenefitID");
            this.Property(t => t.BenefitProductID).HasColumnName("BenefitProductID");
            this.Property(t => t.BenefitMonth).HasColumnName("BenefitMonth");
            this.Property(t => t.BenefitYear).HasColumnName("BenefitYear");
            this.Property(t => t.URI).HasColumnName("URI");
            this.Property(t => t.URIType).HasColumnName("URIType");
            this.Property(t => t.ProcessDatetime).HasColumnName("ProcessDatetime");
            this.Property(t => t.ProcessErrorID).HasColumnName("ProcessErrorID");
            this.Property(t => t.XmlData).HasColumnName("XmlData");
        }
    }
}
