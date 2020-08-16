using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Infrastructure.Sql.Context
{
    public interface ITravelPlansContext
    {
        public DbSet<TravelPlan> TravelPlans { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
