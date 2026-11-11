using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

//Dupla: Matheus Penteado de Barros Pantojo e Joao Victor Sinopolli

namespace TP04.Dominio
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 10000, ErrorMessage = "Preço inválido.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        public int QuantidadeEstoque { get; set; }
    }
}
