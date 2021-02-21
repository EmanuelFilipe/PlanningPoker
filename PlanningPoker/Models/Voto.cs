using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
