﻿using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System.Linq;

namespace PlanningPoker.Controllers
{
    public class HistoriaUsuariosController : Controller
    {
        private readonly IHistoriaUsuarioRepository _historiaUsuarioRepository;

        public HistoriaUsuariosController(IHistoriaUsuarioRepository historiaUsuarioRepository)
        {
            _historiaUsuarioRepository = historiaUsuarioRepository;
        }

        public IActionResult Index()
        {
            return Json(_historiaUsuarioRepository.GetAll());
        }

        public IActionResult GetHistoriaUsuario(int id)
        {
            var model = _historiaUsuarioRepository.GetHistoriaUsuarioById(id);

            if (model == null)
                return NotFound();

            return Json(model);
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

        [HttpPost]
        public IActionResult Alterar([FromBody]HistoriaUsuario model)
        {
            if (ModelState.IsValid)
            {
                _historiaUsuarioRepository.Alterar(model);
                return Ok(_historiaUsuarioRepository.GetHistoriaUsuarioById(model.Id));
            }

            return BadRequest();
        }

        [HttpPost]
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