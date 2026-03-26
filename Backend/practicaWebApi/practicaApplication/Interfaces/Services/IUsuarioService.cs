using practica.Application.Models.DTOs;
using practica.Application.Models.Request.Usuario;
using practica.Application.Models.Response;

namespace practica.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public GenericResponse<UsuarioDto> Create(CreatedUsuarioRequest model);
        public GenericResponse<UsuarioDto> Update(Guid usuarioId, UpdateUsuarioRequest model);

        public GenericResponse<List<UsuarioDto>> GetAll(int limit, int Offeset);


        public GenericResponse<UsuarioDto> GetId(Guid usuarioId);

        public GenericResponse<bool> Delete(Guid usuarioId);
    }
}
