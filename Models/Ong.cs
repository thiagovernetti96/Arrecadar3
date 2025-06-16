using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Arrecadar3.Models
{
    public class Ong
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-ZÀ-ú\s'-]+$")]
        public string Nome { get; set; }


        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }


        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$|^\d{14}$", ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; }

        public string Telefone { get; set; }

        [Required]
        [Range(4, 100)]
        public string Area_Atuacao { get; set; }

        [Required]
        [Range(10, 1000)]
        public string Descricao { get; set; }

        public string? Foto_Perfil_Url { get; set; }



    }
}
