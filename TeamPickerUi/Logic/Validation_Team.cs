using FluentValidation;
using TeamPickerUi.Models;

namespace TeamPickerUi.Logic
{
    public class Validation_Team : AbstractValidator<TeamModel>
    {
        //private readonly List<MemberModel> existingMembers;

        public Validation_Team()
        {
            RuleFor(team => team.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 30).WithMessage("Name must be between 1 and 30 characters dffg.");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x._storage.Teams.Any(q => q.Name == x.Name))
                {
                    context.AddFailure("Name must be unique.");
                }
            });

        }

    }
}
