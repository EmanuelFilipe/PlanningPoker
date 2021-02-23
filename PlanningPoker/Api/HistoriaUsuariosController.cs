using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System.Linq;

namespace PlanningPoker.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriaUsuariosController : ControllerBase
    {
        private readonly IHistoriaUsuarioRepository _historiaUsuarioRepository;

        public HistoriaUsuariosController(IHistoriaUsuarioRepository historiaUsuarioRepository)
        {
            _historiaUsuarioRepository = historiaUsuarioRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_historiaUsuarioRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetHistoriaUsuario(int id)
        {
            var model = _historiaUsuarioRepository.GetHistoriaUsuarioById(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }


        [HttpPost]
        public IActionResult Incluir([FromBody]HistoriaUsuario model)
        {
            if (ModelState.IsValid)
            {
                _historiaUsuarioRepository.Incluir(model);
                var historiaUsuario = _historiaUsuarioRepository.GetAll().Last();

                return Ok(historiaUsuario);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody]HistoriaUsuario model)
        {
            if (ModelState.IsValid)
            {
                _historiaUsuarioRepository.Alterar(model);
                return Ok(_historiaUsuarioRepository.GetHistoriaUsuarioById(model.Id));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var model = _historiaUsuarioRepository.GetHistoriaUsuarioById(id);

            if (model == null)
                return NotFound();

            _historiaUsuarioRepository.Excluir(model);

            return NoContent();
        }
    }
}