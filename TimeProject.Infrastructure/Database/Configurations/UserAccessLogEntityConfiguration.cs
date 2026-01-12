using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Database.Configurations;

public class UserAccessLogEntityConfiguration : IEntityTypeConfiguration<UserAccessLog>
{
    public void Configure(EntityTypeBuilder<UserAccessLog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.IpAddress).IsRequired().HasMaxLength(45);
        builder.Property(e => e.UserAgent).IsRequired();
        builder.Property(e => e.AccessType).IsRequired();
        builder.Property(e => e.AccessAt).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
    }
}