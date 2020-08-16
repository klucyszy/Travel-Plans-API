using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Infrastructure.Sql.Configurations
{
    public class TravelPlansConfiguration : IEntityTypeConfiguration<TravelPlan>
    {
        public void Configure(EntityTypeBuilder<TravelPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Ignore(x => x.Locations);
        }
    }
}
