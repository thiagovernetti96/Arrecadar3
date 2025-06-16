using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arrecadar3.Models
{
    public class Doacao
    {
        public int Id { get; set; }
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
        //[ForeignKey(nameof(Campanha))]

        public decimal Valor_Doado { get; set; }
        public DateTime Data { get; set; }
        public enum Metodo_Pagamento { Credito, Debito, Pix, Boleto };
        [Required]
        public Metodo_Pagamento Metodo { get; set; }
        public enum Status_Doacao { Pendente, Processando, Concluida, Falha, Cancelada, Reembolsada }
        [Required]
        public Status_Doacao Status { get; set; }
    }
}
