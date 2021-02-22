using PlanningPoker.Data.Context;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker.Data.Repositories
{
    public class HistoriaUsuarioRepository : IHistoriaUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public HistoriaUsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Incluir(HistoriaUsuario historiaUsuario)
        {
            _context.HistoriaUsuarios.Add(historiaUsuario);
            _context.SaveChanges();
        }

        public void Alterar(HistoriaUsuario historiaUsuario)
        {
            var model = GetHistoriaUsuarioById(historiaUsuario.Id);

            if (model == null)
                throw new ArgumentNullException("HistoriaUsuario");

            model.Descricao = historiaUsuario.Descricao;

            _context.HistoriaUsuarios.Update(model);
            _context.SaveChanges();
        }

        public void Excluir(HistoriaUsuario historiaUsuario)
        {
            _context.HistoriaUsuarios.Remove(historiaUsuario);
            _context.SaveChanges();
        }

        public HistoriaUsuario GetHistoriaUsuarioById(int id)
        {
            return _context.HistoriaUsuarios.Find(id);
        }

        public IList<HistoriaUsuario> GetAll()
        {
            return _context.HistoriaUsuarios.ToList();
        }
    }
}
