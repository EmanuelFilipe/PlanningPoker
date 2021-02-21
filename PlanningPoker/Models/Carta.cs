using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Models
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ValorCarta { get; set; }
    }
}
