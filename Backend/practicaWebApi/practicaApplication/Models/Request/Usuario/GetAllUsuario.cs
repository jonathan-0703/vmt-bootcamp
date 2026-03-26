namespace practica.Application.Models.Request.Usuario
{
    public class GetAllUsuario
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string? Nombre { get; set; }

        public string Apellido { get; set; }


    }
}
