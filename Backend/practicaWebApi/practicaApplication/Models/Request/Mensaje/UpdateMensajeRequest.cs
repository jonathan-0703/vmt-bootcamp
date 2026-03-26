using System.ComponentModel.DataAnnotations;
using TalentInsing.Shared.Constas;

namespace practica.Application.Models.Request.Mensaje
{
    public class UpdateMensajeRequest
    {
        [Required(ErrorMessage = ValidatorContants.REQUERID)]
        [MaxLength(250, ErrorMessage = ValidatorContants.MAX_LENGHT)]
        [MinLength(1, ErrorMessage = ValidatorContants.MIN_LENGT)]
        public string Contenido { get; set; } = null!;
    }
}
