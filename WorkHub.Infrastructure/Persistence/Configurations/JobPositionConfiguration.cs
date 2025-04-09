using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkHub.Domain.Entities;

namespace WorkHub.Infrastructure.Persistence.Configurations;

public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
{
    public void Configure(EntityTypeBuilder<JobPosition> builder)
    {
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Title).IsRequired().HasMaxLength(100);
        builder.Property(j => j.Description).HasMaxLength(255);
        builder.Property(j => j.SalaryRange).HasColumnType("decimal(18,2)");
        builder.HasOne(j => j.Company).WithMany().HasForeignKey(j => j.CompanyId).OnDelete(DeleteBehavior.Restrict);
    }
}
