using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;
using TravelPlans.Infrastructure.Sql.Context;

namespace Infrastructure.Repositories
{
    internal sealed class TravelPlansRepository : ITravelPlansRepository
    {
        private readonly ITravelPlansContext _context;

        public TravelPlansRepository(ITravelPlansContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TravelPlan travelPlan)
        {
            await _context.TravelPlans.AddAsync(travelPlan);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            TravelPlan travelPlan = await GetAsync(id);
            if (travelPlan is null)
            {
                return;
            }

            _context.Detach(travelPlan);
            _context.TravelPlans.Remove(travelPlan);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            TravelPlan travelPlan = await _context.TravelPlans.FindAsync(id);
            _context.Detach(travelPlan);
            return travelPlan != null;
        }

        public async Task<IEnumerable<TravelPlan>> GetAllAsync(string userId = null)
        {
            return string.IsNullOrEmpty(userId)
                ? _context.TravelPlans
                : _context.TravelPlans.Where(tp => tp.UserId == userId);
        }

        public async Task<TravelPlan> GetAsync(int id)
        {
            return await _context.TravelPlans.FindAsync(id);
        }

        public async Task UpdateAsync(TravelPlan travelPlan)
        {
            _context.TravelPlans.Update(travelPlan);
            await _context.SaveChangesAsync();
        }
    }
}
