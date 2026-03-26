namespace practica.Application.Models.Response
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; } = true;

        public object Metadata { get; set; } = null!;
    }
}
