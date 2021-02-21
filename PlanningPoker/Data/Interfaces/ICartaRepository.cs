using PlanningPoker.Models;
using System.Collections.Generic;

namespace PlanningPoker.Data.Interfaces
{
    public interface ICartaRepository
    {
        void Incluir(Carta carta);
        void Alterar(Carta carta);
        void Excluir(Carta carta);
        Carta GetCartaById(int id);
        IList<Carta> GetAll();
    }
}
