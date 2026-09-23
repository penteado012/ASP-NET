using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TP02.Models;

namespace SistemaBLContainer.Models
{
    public class BL
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número do BL é obrigatório.")]
        [Display(Name = "Número")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Consignee é obrigatório.")]
        public string Consignee { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Navio é obrigatório.")]
        public string Navio { get; set; } = string.Empty;

        // Relacionamento: 1 BL pode ter N Containers
        public virtual ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}