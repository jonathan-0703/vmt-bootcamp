using Microsoft.AspNetCore.Mvc;
using practica.Application.Interfaces.Services;
using practica.Application.Models.Request.Usuario;

namespace practicaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService _usuarioService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedUsuarioRequest model)
        {
            var response = _usuarioService.Create(model);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = _usuarioService.GetAll(10, 0);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var response = _usuarioService.GetId(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioRequest model, Guid id)
        {
            var response = _usuarioService.Update(id, model);
            return Ok(response);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = _usuarioService.Delete(id);
            return Ok(response);

        }

    }
}
