using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;

namespace PlanningPoker.Api.V1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_usuarioRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var model = _usuarioRepository.GetUsuarioById(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody]Usuario model)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Incluir(model);
                var usuario = _usuarioRepository.GetAll().Last();

                return Ok(usuario);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody]Usuario model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioRepository.Alterar(model);
                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
                
                return Ok(_usuarioRepository.GetUsuarioById(model.Id));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var model = _usuarioRepository.GetUsuarioById(id);

            if (model == null)
                return NotFound();

            _usuarioRepository.Excluir(model);

            return NoContent();
        }
    }
}
