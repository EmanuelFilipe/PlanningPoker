using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;

namespace PlanningPoker.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return Json(_usuarioRepository.GetAll());
        }

        public IActionResult GetUsuario(int id)
        {
            var model = _usuarioRepository.GetUsuarioById(id);

            if (model == null)
                return NotFound();

            return Json(model);
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

        [HttpPost]
        public IActionResult Alterar([FromBody]Usuario model)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.Alterar(model);
                return Ok(_usuarioRepository.GetUsuarioById(model.Id));
            }

            return BadRequest();
        }

        [HttpPost]
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