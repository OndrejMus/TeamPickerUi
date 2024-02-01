using FluentValidation;
using TeamPickerUi.Models;

namespace TeamPickerUi.Logic
{
    public class Validation_Member : AbstractValidator<MemberModel>
    {
        //private readonly List<MemberModel> existingMembers;

        public Validation_Member()
        {
            RuleFor(member => member.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 30).WithMessage("Name must be between 1 and 30 characters dffg.");

            RuleFor(member => member.Rating)
                .NotEmpty().WithMessage("Rating is required")
                .GreaterThanOrEqualTo(1).WithMessage("Rating must be bigger than 1.")
                .LessThanOrEqualTo(10000).WithMessage("Rating must be smaller than 10 000.");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x._storage.Members.Any(q => q.Name == x.Name)) 
                {
                    context.AddFailure("Name must be unique.");
                }
            });

        }

    }
}
