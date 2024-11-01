using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicaManager.Domain.Entities;

namespace TicaManager.Infra.Database.Mappings;

public class AuditMap : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.ToTable("Audit");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Action)
            .IsRequired()
            .HasColumnName("Action")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);
        builder.Property(e => e.EmployeeId)
            .IsRequired()
            .HasColumnName("EmployeeId")
            .HasColumnType("VARCHAR");
        builder.Property(e => e.Date)
            .IsRequired()
            .HasColumnName("Date")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        builder.HasIndex(e => e.EmployeeId, "IX_Audit_EmployeeId").IsUnique();
    }
}