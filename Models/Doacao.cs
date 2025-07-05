using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arrecadar3.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Campanha))]
        [Display(Name = "Campanha")]
        public int CampanhaId { get; set; }
        public Campanha? Campanha { get; set; }

        [Display(Name = "Valor Doado")]
        public decimal Valor_Doado { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
