using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Infrastructure.Sql.Context
{
    public class TravelPlansContext : DbContext, ITravelPlansContext
    {
        public DbSet<TravelPlan> TravelPlans { get; set; }

        public TravelPlansContext() { }
        public TravelPlansContext(DbContextOptions<TravelPlansContext> opts)
            : base(opts)
        {
        }

        public void Detach(TravelPlan travelPlan)
        {
            if (travelPlan is null)
            {
                return;
            }

            base.Entry(travelPlan).State = EntityState.Detached;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
