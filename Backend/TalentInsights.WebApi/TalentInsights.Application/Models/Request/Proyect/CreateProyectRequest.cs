using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace TalentInsights.Application.Models.Request.Proyect
{
    public class CreateProyectRequest
    {
        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(200, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string ProyectName { get; set; } = null!;

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(100, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string ProyectDescription { get; set; } = null!;
    }
}
