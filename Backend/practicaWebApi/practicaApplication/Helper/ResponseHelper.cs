using practica.Application.Models.Response;

namespace practica.Application.Helper
{
    public class ResponseHelper
    {
        public static GenericResponse<T> create<T>(T data, string message = "Solicitud realizada correctamente", object? metadata = null, bool success = true)
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message,
                Success = success,
                Metadata = metadata
            };
        }
    }
}
