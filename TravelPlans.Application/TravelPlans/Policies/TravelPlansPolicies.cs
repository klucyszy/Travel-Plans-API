using TravelPlans.Application.TravelPlans.Exceptions;

namespace TravelPlans.Application.TravelPlans.Policies
{
    public static class TravelPlansPolicies
    {
        public static void ValidateIsAdminOrAddingAccessingOwnTravelPlan(bool isAdmin, string currentUserId, string requestUserId)
        {
            if (isAdmin || currentUserId == requestUserId)
            {
                return;
            }

            throw new InsufficientPrivilidgesException();
        }
    }
}
