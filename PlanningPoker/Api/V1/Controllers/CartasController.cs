using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System;
using System.Linq;

namespace PlanningPoker.Api.V1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CartasController : ControllerBase
    {
        private readonly ICartaRepository _cartaRepository;

        public CartasController(ICartaRepository cartaRepository)
        {
            _cartaRepository = cartaRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_cartaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetCarta(int id)
        {
            var model = _cartaRepository.GetCartaById(id);

            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Incluir([FromBody]Carta model)
        {
            if (ModelState.IsValid)
            {
                _cartaRepository.Incluir(model);
                var carta = _cartaRepository.GetAll().Last();

                return Ok(carta);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody]Carta model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cartaRepository.Alterar(model);
                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
                
                return Ok(_cartaRepository.GetCartaById(model.Id));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var model = _cartaRepository.GetCartaById(id);

            if (model == null)
                return NotFound();

            _cartaRepository.Excluir(model);

            return NoContent();
        }
    }
}