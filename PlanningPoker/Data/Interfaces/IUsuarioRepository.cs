using PlanningPoker.Models;
using System.Collections.Generic;

namespace PlanningPoker.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        Usuario GetUsuarioById(int id);
        IList<Usuario> GetAll();
    }
}
