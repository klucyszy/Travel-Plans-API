using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelPlans.Infrastructure.Sql.Entities;

namespace TravelPlans.Infrastructure.Sql.Configurations
{
    internal sealed class TravelPlansConfiguration : IEntityTypeConfiguration<TravelPlanEntity>
    {
        public void Configure(EntityTypeBuilder<TravelPlanEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
        }
    }
}
