using practica.Application.Models.DTOs;
using practica.Application.Models.Request.Mensaje;
using practica.Application.Models.Response;

namespace practica.Application.Interfaces.Services
{
    public interface IMensajeService
    {

        public GenericResponse<MensajeDto> Create(CreatedMensajeRequest model);
        public GenericResponse<MensajeDto> Update(Guid mensajeId, UpdateMensajeRequest model);

        public GenericResponse<List<MensajeDto>> GetAll(int limit, int Offeset);


        public GenericResponse<MensajeDto> GetId(Guid mensajeId);

        public GenericResponse<bool> Delete(Guid mensajeId);
    }
}
