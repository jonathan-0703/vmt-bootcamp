using Microsoft.AspNetCore.Mvc;
using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Servicio;
using TalentInsights.Application.Models.Request.Collaborator;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController(ICollaboratorService collaboratorService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorRequest model)
        {
            var rsp = collaboratorService.Create(model);
            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] GetAllProyectRequest model)
        {
            List<string> user = ["Usuario 1", "Usuario 2", "Usuario 3"];
            return Ok(ResponseHelper.Create(user));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var context = HttpContext;

            var usuarioId = $"{id}";

            return Ok(ResponseHelper.Create(usuarioId));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateCollaboratorRequest model, Guid id)
        {
            return Ok($"Uusuario actualizado: {id}-{model.FullName}");
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok($"Usuario Eliminado: {id}");
        }

        [HttpPatch("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasssordCollaborator model)
        {
            return Ok($"Usuario Contraseña cambiada : {model.CurrentPassword} - {model.NewPassword}");
        }
    }
}
