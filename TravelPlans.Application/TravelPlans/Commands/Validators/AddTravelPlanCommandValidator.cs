using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelPlans.Application.TravelPlans.Commands.Validators
{
    public class AddTravelPlanCommandValidator : AbstractValidator<AddTravelPlanCommand>
    {
        public AddTravelPlanCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty()
                .WithMessage("UserId is required");
            RuleFor(v => v.Name)
                .NotEmpty()
                .MaximumLength(26);
            RuleFor(v => v.StartDate)
                .Must((args, startDate) => BeSmallerOrEqualThan(startDate, args.EndDate))
                .WithMessage("Start Date must be smaller than End Date");
            RuleFor(v => v.EndDate)
                .Must((args, endDate) => BeSmallerOrEqualThan(args.StartDate, endDate))
                .WithMessage("End Date must be greater than Start Date");
            RuleFor(v => v.Locations)
                .Must(BeNotEmptyWithAtLeastOneItem)
                .WithMessage("At least one location must be set");
        }

        private bool BeNotEmptyWithAtLeastOneItem(IEnumerable<string> arg)
        {
            if (arg is null)
            {
                return false;
            }

            return arg.Any();
        }

        private bool BeSmallerOrEqualThan(DateTime? startDate, DateTime? endDate)
        {
            if (!startDate.HasValue || !endDate.HasValue)
            {
                return false;
            }

            return startDate.Value < endDate.Value;
        }
    }
}
