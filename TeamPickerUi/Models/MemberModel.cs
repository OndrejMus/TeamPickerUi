using System.ComponentModel.DataAnnotations;
using TeamPickerUi.Logic;

namespace TeamPickerUi.Models;

public class MemberModel
{
    //[Required]
    //[MinLength(1, ErrorMessage = "Name is too short.")]
    //[StringLength(30, ErrorMessage = "Name too long.")]
    public string Name { get; set; }

    //[Required]
    //[Range(1,10000, ErrorMessage ="Rating needs to be between 1 and 10 000.")]
    public int Rating { get; set; } = 1000;

    public string MemberColorHex { get; set; }

    // Reference to TeamStorage so validation for unique name can be done with onln MemberModel object and can check content of whole Members collection
    public readonly ITeamStorage _storage;

    public MemberModel(ITeamStorage teamStorage)
    {
        _storage = teamStorage;
    }
}
