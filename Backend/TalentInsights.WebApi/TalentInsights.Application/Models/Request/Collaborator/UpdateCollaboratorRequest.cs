using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace TalentInsights.Application.Models.Request.Collaborator
{
    public class UpdateCollaboratorRequest
    {

        [MaxLength(150, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]

        public string FullName { get; set; }

        [MaxLength(255, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string? GitlabProfile { get; set; }


        [MaxLength(100, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Positions { get; set; }
    }
}
