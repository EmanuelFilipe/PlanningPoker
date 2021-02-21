using Microsoft.EntityFrameworkCore;
using PlanningPoker.Models;

namespace PlanningPoker.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }

}
