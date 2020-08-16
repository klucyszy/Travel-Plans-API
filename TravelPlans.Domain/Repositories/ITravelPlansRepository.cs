using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlans.Domain.Entities;

namespace Domain.Repositories
{
    public interface ITravelPlansRepository
    {
        Task<TravelPlan> GetAsync(int id);
        Task<IEnumerable<TravelPlan>> GetAllAsync(string userId = null);
        Task<bool> ExistsAsync(int id);
        Task AddAsync(TravelPlan travelPlan);
        Task UpdateAsync(TravelPlan travelPlan);
        Task DeleteAsync(int id);
    }
}
