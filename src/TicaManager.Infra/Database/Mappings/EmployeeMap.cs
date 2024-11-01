using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicaManager.Domain.Entities;

namespace TicaManager.Infra.Database.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnType("VARCHAR");
        builder.ComplexProperty(e => e.Name, a =>
        {
            a.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
        });

        builder.OwnsOne(e => e.Email, a =>
        {
            a.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            a.HasIndex(e => e.Address).HasDatabaseName("IX_Employee_Email");
        });

        builder.OwnsOne(e => e.Cpf, a =>
        {
            a.Property(x => x.Number)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);
            a.HasIndex(e => e.Number).HasDatabaseName("IX_Employee_Cpf");
        });
            
        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");

        builder.HasMany(e => e.Audits)
            .WithOne(e => e.Employee)
            .HasForeignKey(e => e.EmployeeId)
            .IsRequired()
            .HasConstraintName("FK_Employee_Audit");
    }
    
}