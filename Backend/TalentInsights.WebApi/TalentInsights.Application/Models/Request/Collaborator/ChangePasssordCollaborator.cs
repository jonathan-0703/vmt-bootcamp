using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace TalentInsights.Application.Models.Request.Collaborator
{
    public class ChangePasssordCollaborator
    {

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        public string NewPassword { get; set; } = null!;
    }
}
