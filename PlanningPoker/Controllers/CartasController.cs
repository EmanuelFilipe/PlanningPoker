using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System.Linq;

namespace PlanningPoker.Controllers
{
    public class CartasController : Controller
    {
        private readonly ICartaRepository _cartaRepository;

        public CartasController(ICartaRepository cartaRepository)
        {
            _cartaRepository = cartaRepository;
        }

        public IActionResult Index()
        {
            return Json(_cartaRepository.GetAll());
        }

        public IActionResult GetCarta(int id)
        {
            var model = _cartaRepository.GetCartaById(id);

            if (model == null)
                return NotFound();

            return Json(model);
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

        [HttpPost]
        public IActionResult Alterar([FromBody]Carta model)
        {
            if (ModelState.IsValid)
            {
                _cartaRepository.Alterar(model);
                return Ok(_cartaRepository.GetCartaById(model.Id));
            }

            return BadRequest();
        }

        [HttpPost]
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