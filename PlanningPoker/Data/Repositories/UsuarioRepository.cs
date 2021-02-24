using PlanningPoker.Data.Context;
using PlanningPoker.Data.Interfaces;
using PlanningPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Incluir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            var user = GetUsuarioById(usuario.Id);

            if (user == null)
                throw new ArgumentNullException();

            user.Nome = usuario.Nome;

            _context.Usuarios.Update(user);
            _context.SaveChanges();
        }

        public void Excluir(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public IList<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }
    }
}
