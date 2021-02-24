using PlanningPoker.Data.Context;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker.Data.Repositories
{
    public class CartaRepository : ICartaRepository
    {
        private readonly ApplicationContext _context;

        public CartaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Incluir(Carta carta)
        {
            _context.Cartas.Add(carta);
            _context.SaveChanges();
        }

        public void Alterar(Carta carta)
        {
            var model = GetCartaById(carta.Id);

            if (model == null)
                throw new ArgumentNullException();

            model.ValorCarta = carta.ValorCarta;

            _context.Cartas.Update(model);
            _context.SaveChanges();
        }

        public void Excluir(Carta carta)
        {
            _context.Cartas.Remove(carta);
            _context.SaveChanges();
        }

        public Carta GetCartaById(int id)
        {
            return _context.Cartas.Find(id);
        }

        public IList<Carta> GetAll()
        {
            return _context.Cartas.ToList();
        }
    }
}
