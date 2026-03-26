namespace practica.Application.Models.DTOs
{
    public class UsuarioDto
    {
        public Guid UsuariosId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string? Descriptions { get; set; }

        public string Celular { get; set; }

        public string? FotoPerfil { get; set; }

        public bool IsActive { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
