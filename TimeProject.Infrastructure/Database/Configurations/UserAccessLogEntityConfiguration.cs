using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class UserAccessLogEntityConfiguration : IEntityTypeConfiguration<UserAccessLogEntity>
{
    public void Configure(EntityTypeBuilder<UserAccessLogEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.IpAddress).IsRequired().HasMaxLength(45);
        builder.Property(e => e.UserAgent).IsRequired();
        builder.Property(e => e.AccessType).IsRequired();
        builder.Property(e => e.AccessAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(e => e.UserId);
    }
}