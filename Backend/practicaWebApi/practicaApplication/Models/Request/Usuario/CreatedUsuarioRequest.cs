using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace practica.Application.Models.Request.Usuario
{
    public class CreatedUsuarioRequest
    {


        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(250, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(5, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(250, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(5, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(250, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [EmailAddress(ErrorMessage = ValidatorContants.EMAIL)]
        [MinLength(5, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(14, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Celular { get; set; } = null!;

        [MaxLength(255, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(10, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string? FotoPerfil { get; set; } = null!;

    }
}
