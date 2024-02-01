using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using TeamPickerUi.Logic;
using TeamPickerUi.Pages;

namespace TeamPickerUi.Models;

public class TeamModel
{
    public string Name { get; set; }
    public List<MemberModel> Members { get; set; } = new List<MemberModel>();
    public string TeamColorHex { get; set; }

    public int WinCount { get; set; } = 0;
    public int LossCount { get; set; } = 0;

    public int GetTeamRating()
    {
        int teamRating = 0;
        foreach (var member in Members)
        {
            teamRating += member.Rating;
        }
        return teamRating;
    }


    // Reference to TeamStorage so validation for unique name can be done with onln TeamModel object and can check content of whole Teams collection
    public readonly ITeamStorage _storage;

    public TeamModel(ITeamStorage teamStorage)
    {
        _storage = teamStorage;
    }
}
