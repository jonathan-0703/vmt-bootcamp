using practica.Application.Helper;
using practica.Application.Interfaces.Services;
using practica.Application.Models.DTOs;
using practica.Application.Models.Request.Mensaje;
using practica.Application.Models.Response;
using TalentInsing.Shared;
using TalentInsing.Shared.Helper;

namespace practica.Application.Services
{
    public class MensajeService(Cache<MensajeDto> _cache) : IMensajeService
    {
        public GenericResponse<MensajeDto> Create(CreatedMensajeRequest model)
        {
            var mensaje = new MensajeDto
            {
                MensajeId = Guid.NewGuid(),
                Contenido = model.Contenido,
                TipoDocumento = model.TipoDocumento,
                RespuestaMensaje = model.RespuestaMensaje,
                FechaEnvio = DateTimeHelper.UtcNow(),

            };

            var key = mensaje.MensajeId.ToString();
            _cache.Add(key, mensaje);
            return ResponseHelper.create(mensaje, "Mensaje creado correctamente");
        }

        public GenericResponse<bool> Delete(Guid mensajeId)
        {
            var key = mensajeId.ToString();
            var mensaje = _cache.Get(key);
            if (mensaje == null)
            {
                return ResponseHelper.create<bool>(
                 data: false,
                 message: $"Mensaje con el ID {mensajeId} no encontrado",
                 success: false
                 );
            }

            var mensajeEliminado = _cache.Delete(key);
            return ResponseHelper.create(mensajeEliminado, mensajeEliminado ? "Mensaje eliminado correctamente" : "No se pudo eliminar el mensaje");

        }

        public GenericResponse<List<MensajeDto>> GetAll(int limit, int offeset)
        {
            var mensaje = _cache.Get();
            var paginacion = mensaje.Skip(offeset).Take(limit).ToList();
            var metada = new
            {
                totalItme = mensaje.Count,
                limit,
                offeset,
            };
            return ResponseHelper.create(paginacion, "Lista Usuario", metada);
        }

        public GenericResponse<MensajeDto> GetId(Guid mensajeId)
        {
            var mensaje = _cache.Get(mensajeId.ToString());
            if (mensaje == null)
            {
                return ResponseHelper.create<MensajeDto>(
                    data: null!,
                    message: $"El mensaje con {mensajeId} no se encontro",
                    metadata: null,
                    success: false
                    );
            }
            return ResponseHelper.create(mensaje, $"El mensaje encontrado correctamente");
        }

        public GenericResponse<MensajeDto> Update(Guid mensajeId, UpdateMensajeRequest model)
        {
            var allMensaje = _cache.Get();

            var mensaje = allMensaje.FirstOrDefault(x => x.MensajeId == mensajeId);

            if (mensaje == null)
            {
                ResponseHelper.create<MensajeDto>(
                    data: null!,
                    message: $"Mensaje con el {mensajeId} no encontrado",
                    metadata: null,
                    success: false
                 );

            }
            mensaje.Contenido = model.Contenido;
            mensaje.FechaActualizacion = DateTimeHelper.UtcNow();

            _cache.Delete(mensajeId.ToString());
            _cache.Add(mensajeId.ToString(), mensaje);

            return ResponseHelper.create(mensaje, "Se actualizado correctamente el Mensaje");

        }
    }
}
