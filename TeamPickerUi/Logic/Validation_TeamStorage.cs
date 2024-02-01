using FluentValidation;
using TeamPickerUi.Models;
using TeamPickerUi.Pages;

namespace TeamPickerUi.Logic
{
    public class Validation_TeamStorage : AbstractValidator<TeamStorage>
    {
        //private readonly List<MemberModel> existingMembers;

        public Validation_TeamStorage()
        {
            RuleFor(store => store.Members)
                .NotEmpty().WithMessage("Please add some members.")
                .Must(members => members.Count > 1).WithMessage("Please add at least two members.");

            RuleFor(store => store.Teams)
                .NotEmpty().WithMessage("Please add some teams.")
                .Must(teams => teams.Count > 1).WithMessage("Please add at least two teams.");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Members.Count <= x.Teams.Count) 
                {
                    context.AddFailure("Number of members have to be bigger then number of teams.");
                }
            });

        }

    }
}
