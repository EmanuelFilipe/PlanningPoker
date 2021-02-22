using PlanningPoker.Models;

namespace PlanningPoker.ViewModels
{
    public class VotoViewModel
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Carta Carta { get; set; }
        public HistoriaUsuario HistoriaUsuario { get; set; }
    }
}
