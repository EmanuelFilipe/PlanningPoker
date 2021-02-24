using PlanningPoker.Data.Context;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPoker.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly ApplicationContext _context;

        public VotoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Incluir(Voto voto)
        {
            _context.Votos.Add(voto);
            _context.SaveChanges();
        }

        public void Alterar(Voto voto)
        {
            var model = GetVotoById(voto.Id);

            if (model == null)
                throw new ArgumentNullException();

            _context.Votos.Update(model);
            _context.SaveChanges();
        }

        public void Excluir(Voto voto)
        {
            _context.Usuarios.Remove(voto.Usuario);
            _context.Cartas.Remove(voto.Carta);
            _context.HistoriaUsuarios.Remove(voto.HistoriaUsuario);
            _context.Votos.Remove(voto);

            _context.SaveChanges();
        }

        public IList<Voto> GetAll()
        {
            return _context.Votos.ToList();
        }

        public Voto GetVotoById(int id)
        {
            return _context.Votos.Find(id);
        }

    }
}
