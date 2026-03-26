using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace TalentInsights.Application.Models.Request.Collaborator
{
    public class CreateCollaboratorRequest
    {
        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(150, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]

        public string FullName { get; set; } = null!;

        [MaxLength(255, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string? GitlabProfile { get; set; }

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(100, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Positions { get; set; } = null!;
    }
}
