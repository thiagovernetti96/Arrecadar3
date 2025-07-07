using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arrecadar3.Models
{
    public class Campanha
    {
            [Required]
            [Key]
            public int Id { get; set; }

            [RegularExpression(@"^[a-zA-ZÀ-ú\s'-]+$")]
            public string Titulo { get; set; }

            [Required]
            [ForeignKey(nameof(Ongs))]
            [Display(Name = "Ong")]
            public int OngId { get; set; }

           
            public Ong? Ongs { get; set; }

            [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
            [Display(Name = "Descrição")]
            public string Descricao { get; set; }
            [Display(Name = "Meta de Arrecadação")]
            public decimal? Meta_Arrecadacao { get; set; }

            [Display(Name ="Valor Arrecadado")]  
            public decimal? Valor_Arrecadado
            {
                get => Doacoes?.Sum(d => d.Valor_Doado) ?? 0;
                set { } 
            }

            public ICollection<Doacao>? Doacoes { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name ="Data de Início")]
            public DateTime Data_Inicio { get; set; }
        
        public byte[]? Foto_Perfil { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        [Display(Name = "Foto da Campanha")]
        public IFormFile? Foto_Perfil_Arquivo { get; set; }

        public enum Status
            {
                Ativa,
                Suspensa,
            }
            public static Status Set(string status)
            {
                return Enum.TryParse(status, true, out Status result)
                    ? result
                    : throw new ArgumentException("Status inválido. Use 'Ativa' ou 'Suspensa'.");
            }
    }
}
