using Microsoft.AspNetCore.Mvc;
using practica.Application.Interfaces.Services;
using practica.Application.Models.Request.Mensaje;

namespace practicaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeController(IMensajeService _mensajeService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedMensajeRequest model)
        {
            var response = _mensajeService.Create(model);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = _mensajeService.GetAll(9, 0);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var response = _mensajeService.GetId(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateMensajeRequest model, Guid id)
        {
            var response = _mensajeService.Update(id, model);
            return Ok(response);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = _mensajeService.Delete(id);
            return Ok(response);

        }
    }
}
