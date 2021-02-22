using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Models
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int CartaId { get; set; }
        public Carta Carta { get; set; }

        public int HistoriaUsuarioId { get; set; }
        public HistoriaUsuario HistoriaUsuario { get; set; }
    }
}
