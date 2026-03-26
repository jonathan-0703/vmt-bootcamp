using TalentInsights.Application.Models.Response;

namespace TalentInsights.Application.Helpers
{
    public class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud realizada corectamente")
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message,


            };
        }
    }
}