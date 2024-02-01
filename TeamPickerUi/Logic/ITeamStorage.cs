using FluentValidation.Results;
using TeamPickerUi.Models;

namespace TeamPickerUi.Logic
{
    public interface ITeamStorage
    {
        List<MemberModel> Members { get; set; }
        List<TeamModel> Teams { get; set; }

        event Action StorageUpdated;

        //void AddMember(MemberModel member);
        void AddTeamMember(TeamModel team, MemberModel member);
        void RemoveMember(MemberModel member);
        void RemoveTeamMember(TeamModel team, MemberModel member);
        void AddTeam(TeamModel team);
        void RemoveTeam(TeamModel team);
        void AddMember(MemberModel member);
        void RandomizeTeams();
    }
}