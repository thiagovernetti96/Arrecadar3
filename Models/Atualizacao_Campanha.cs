using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arrecadar3.Models
{
    public class Atualizacao_Campanha
    {

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Campanha))]
        [Display(Name = "Campanha")]
        public int CampanhaId { get; set; }
        public Campanha? Campanha { get; set; }

        [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
        public string Titulo { get; set; }

        [RegularExpression(@"^[a-zA-ZÀ-ú0-9\s']+$")]
        public string Descricao { get; set; }

        public byte[]? Foto_Perfil { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        public IFormFile? Foto_Perfil_Arquivo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Publicacao { get; set; }
    }
}
