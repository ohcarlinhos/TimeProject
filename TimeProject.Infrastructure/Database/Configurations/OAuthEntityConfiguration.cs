using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class OAuthEntityConfiguration : IEntityTypeConfiguration<OAuthEntity>
{
    public void Configure(EntityTypeBuilder<OAuthEntity> builder)
    {
        builder.HasKey(e => new { e.UserId, e.Provider });

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Provider).HasMaxLength(15).IsRequired();
        builder.Property(e => e.UserProviderId).HasMaxLength(36).IsRequired();

        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);
    }
}