using FluentValidation;

namespace TravelPlans.Application.TravelPlans.Commands.Validators
{
    public class AddTravelPlanCommandValidator : AbstractValidator<AddTravelPlanCommand>
    {
        public AddTravelPlanCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required");
        }
    }
}
