using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPoker.Data.Context;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using PlanningPoker.ViewModels;
using System.Linq;

namespace PlanningPoker.Api
{
    [ApiController]
    [Route("[controller]")]
    public class VotosController : ControllerBase
    {
        private readonly IVotoRepository _votoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICartaRepository _cartaRepository;
        private readonly IHistoriaUsuarioRepository _historiaUsuario;
        private readonly ApplicationContext _context;

        public VotosController(IVotoRepository votoRepository, IUsuarioRepository usuarioRepository, 
                               ICartaRepository cartaRepository, IHistoriaUsuarioRepository historiaUsuario, 
                               ApplicationContext context)
        {
            _votoRepository = votoRepository;
            _usuarioRepository = usuarioRepository;
            _cartaRepository = cartaRepository;
            _historiaUsuario = historiaUsuario;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var voto = _context.Votos
                           .Include(u => u.Usuario)
                           .Include(c => c.Carta)
                           .Include(h => h.HistoriaUsuario)
                           .Select(v => new VotoViewModel { Id = v.Id, Usuario = v.Usuario, Carta = v.Carta,
                                                            HistoriaUsuario = v.HistoriaUsuario })
                           .ToList();

            return Ok(voto);
        }


        [HttpGet("{id}")]
        public IActionResult GetVoto(int id)
        {
            var voto = _context.Votos
                           .Include(u => u.Usuario)
                           .Include(c => c.Carta)
                           .Include(h => h.HistoriaUsuario)
                           .Select(v => new Voto
                           {
                               Id = v.Id,
                               Usuario = v.Usuario,
                               Carta = v.Carta,
                               HistoriaUsuario = v.HistoriaUsuario
                           })
                           .Where(v => v.Id == id).SingleOrDefault();

            if (voto == null)
                return NotFound();

            return Ok(voto);

        }

        [HttpPost]
        public IActionResult Incluir([FromBody]Voto voto)
        {
            if (ModelState.IsValid)
            {
                InclusaoDeDados(voto);
                _votoRepository.Incluir(voto);

                return Ok(voto);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody]Voto voto)
        {
            if (ModelState.IsValid)
            {
                AlteracaoDeDados(voto);
                _votoRepository.Alterar(voto);

                return Ok(_votoRepository.GetVotoById(voto.Id));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var voto = _context.Votos
                           .Include(u => u.Usuario)
                           .Include(c => c.Carta)
                           .Include(h => h.HistoriaUsuario)
                           .Select(v => new Voto
                           {
                               Id = v.Id,
                               Usuario = v.Usuario,
                               Carta = v.Carta,
                               HistoriaUsuario = v.HistoriaUsuario
                           })
                           .Where(v => v.Id == id).SingleOrDefault();

            if (voto == null)
                return NotFound();

            _votoRepository.Excluir(voto);

            return NoContent();
        }

        #region INCLUSAO

        private Voto InclusaoDeDados(Voto voto)
        {
            voto.UsuarioId = IncluirUsuario(voto.Usuario);
            voto.CartaId = IncluirCarta(voto.Carta);
            voto.HistoriaUsuarioId = IncluirHistoriaUsuario(voto.HistoriaUsuario);

            return voto;
        }

        private int IncluirUsuario(Usuario usuario)
        {
            _usuarioRepository.Incluir(usuario);
            return usuario.Id;
        }

        private int IncluirCarta(Carta carta)
        {
            _cartaRepository.Incluir(carta);
            return carta.Id;
        }

        private int IncluirHistoriaUsuario(HistoriaUsuario historiaUsuario)
        {
            _historiaUsuario.Incluir(historiaUsuario);
            return historiaUsuario.Id;
        }

        #endregion

        #region ALTERACAO

        private Voto AlteracaoDeDados(Voto voto)
        {
            voto.Usuario = AlterarUsuario(voto.Usuario);
            voto.Carta = AlterarCarta(voto.Carta);
            voto.HistoriaUsuario = AlterarHistoriaUsuario(voto.HistoriaUsuario);

            return voto;
        }

        private Usuario AlterarUsuario(Usuario usuario)
        {
            _usuarioRepository.Alterar(usuario);
            return usuario;
        }

        private Carta AlterarCarta(Carta carta)
        {
            _cartaRepository.Alterar(carta);
            return carta;
        }

        private HistoriaUsuario AlterarHistoriaUsuario(HistoriaUsuario historiaUsuario)
        {
            _historiaUsuario.Alterar(historiaUsuario);
            return historiaUsuario;
        }

        #endregion


    }
    
}