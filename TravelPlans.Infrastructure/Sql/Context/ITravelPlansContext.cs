using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;

namespace TravelPlans.Infrastructure.Sql.Context
{
    internal interface ITravelPlansContext
    {
        DbSet<TravelPlan> TravelPlans { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Detach(TravelPlan travelPlan);
    }
}
