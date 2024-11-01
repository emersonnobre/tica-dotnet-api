using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicaManager.Domain.Entities;

namespace TicaManager.Infra.Database.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.Property(e => e.Username)
            .HasColumnName("Username")
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(255);
        builder.HasKey(e => e.Username);
        builder.Property(e => e.PasswordHash)
            .HasColumnName("PasswordHash")
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(255);
        builder.Property(e => e.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETDATE()");
        
        builder.Ignore(e => e.IsValid);
        builder.Ignore(e => e.Notifications);
    }
}