using PlanningPoker.Models;
using System.Collections.Generic;

namespace PlanningPoker.Data.Interfaces
{
    public interface IHistoriaUsuarioRepository
    {
        void Incluir(HistoriaUsuario historiaUsuario);
        void Alterar(HistoriaUsuario historiaUsuario);
        void Excluir(HistoriaUsuario historiaUsuario);
        HistoriaUsuario GetHistoriaUsuarioById(int id);
        IList<HistoriaUsuario> GetAll();
    }
}
