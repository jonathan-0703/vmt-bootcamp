using practica.Application.Helper;
using practica.Application.Interfaces.Services;
using practica.Application.Models.DTOs;
using practica.Application.Models.Request.Usuario;
using practica.Application.Models.Response;
using TalentInsing.Shared;
using TalentInsing.Shared.Helper;

namespace practica.Application.Services
{
    public class UsuarioService(Cache<UsuarioDto> _cache) : IUsuarioService
    {

        public GenericResponse<UsuarioDto> Create(CreatedUsuarioRequest model)
        {
            var usuario = new UsuarioDto
            {
                UsuariosId = Guid.NewGuid(),
                Nombre = model.Nombres,
                Apellido = model.Apellidos,
                Descriptions = model.Description,
                FotoPerfil = model.FotoPerfil,
                Celular = model.Celular,
                FechaCreacion = DateTimeHelper.UtcNow(),
                FechaActualizacion = DateTimeHelper.UtcNow(),


            };

            var key = usuario.UsuariosId.ToString();
            _cache.Add(key, usuario);

            return ResponseHelper.create(usuario, "Usuario creado correctamente");
        }

        public GenericResponse<bool> Delete(Guid usuarioId)
        {
            var key = usuarioId.ToString();
            var usuario = _cache.Get(key);
            if (usuario == null)
            {
                return ResponseHelper.create<bool>(
                 data: false,
                 message: $"Usuario con ID {usuarioId} no encontrado",
                 success: false);
            }
            var eliminado = _cache.Delete(key);
            return ResponseHelper.create(
                eliminado,
                eliminado ? "Usuario eliminado correctamente" : "No se pudo eliminar el usuario"
            );
        }

        public GenericResponse<List<UsuarioDto>> GetAll(int limit, int offeset)
        {
            var usuario = _cache.Get();

            var paginacion = usuario.Skip(offeset).Take(limit).ToList();

            var metada = new
            {
                totaItem = usuario.Count,
                limit,
                offeset,
            };
            return ResponseHelper.create(paginacion, "Lista usuarios", metada);
        }

        public GenericResponse<UsuarioDto> GetId(Guid usuarioId)
        {

            var usuario = _cache.Get(usuarioId.ToString());
            if (usuario == null)
            {
                return ResponseHelper.create<UsuarioDto>(
                    data: null!,
                    message: $"Usuario con ID {usuarioId} no encontrado",
                    metadata: null,
                    success: false
                    );
            }
            return ResponseHelper.create(usuario, "Usuario encontrado corrctamente");
        }

        public GenericResponse<UsuarioDto> Update(Guid usuarioId, UpdateUsuarioRequest model)
        {

            var allUsuario = _cache.Get();


            var usuario = allUsuario.FirstOrDefault(u => u.UsuariosId == usuarioId);
            if (usuario == null)
            {
                return ResponseHelper.create<UsuarioDto>(
                    data: null!,
                    message: $"Usuario con ID {usuarioId} no encontrado",
                    metadata: null,
                    success: false
                    );
            }
            usuario.Nombre = model.Nombres;
            usuario.Apellido = model.Apellidos;
            usuario.Descriptions = model.Description;
            usuario.Celular = model.Celular;
            usuario.FotoPerfil = model.FotoPerfil;
            usuario.FechaActualizacion = DateTimeHelper.UtcNow();


            _cache.Delete(usuarioId.ToString());
            _cache.Add(usuarioId.ToString(), usuario);

            return ResponseHelper.create(usuario, $"Se actualizado correctamente el usuario {usuario.Nombre} ");
        }
    }
}
