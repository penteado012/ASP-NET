using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP02.Models;

namespace SistemaBLContainer.Models
{
    public class Container
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do Container é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número do Container deve ter 11 caracteres.")]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Tipo é obrigatório.")]
        [RegularExpression("^(Dry|Reefer)$", ErrorMessage = "O Tipo deve ser 'Dry' ou 'Reefer'.")]
        public string Tipo { get; set; } = string.Empty; // Dry ou Reefer

        [Required(ErrorMessage = "O Tamanho é obrigatório.")]
        [Range(20, 40, ErrorMessage = "O Tamanho deve ser 20 ou 40.")]
        public int Tamanho { get; set; } // 20 ou 40

        // Chave estrangeira obrigatória (Todo Container DEVE estar associado a um BL)
        [Required(ErrorMessage = "O BL é obrigatório.")]
        [Display(Name = "BL")]
        public int BLId { get; set; }

        [ForeignKey("BLId")]
        public virtual BL? BL { get; set; }
    }
}