using PlanningPoker.Models;
using System.Collections.Generic;

namespace PlanningPoker.Data.Interfaces
{
    public interface IVotoRepository
    {
        void Incluir(Voto voto);
        void Alterar(Voto voto);
        void Excluir(Voto voto);
        Voto GetVotoById(int id);
        IList<Voto> GetAll();
    }
}
