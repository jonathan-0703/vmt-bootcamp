namespace practica.Application.Models.DTOs
{
    public class MensajeDto
    {

        public Guid MensajeId { get; set; }

        public string Contenido { get; set; }

        public string? TipoDocumento { get; set; }

        public string? RespuestaMensaje { get; set; }

        public bool MensajeEliminado { get; set; }

        public DateTime FechaEnvio { get; set; }

        public DateTime FechaActualizacion { get; set; }


    }
}
