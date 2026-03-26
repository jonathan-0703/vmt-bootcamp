namespace practica.Application.Models.Request.Mensaje
{
    public class GetAllMensaje
    {
        public int limit { get; set; }
        public int offset { get; set; }

        public string? ContenidoMensaje { get; set; }
    }
}
