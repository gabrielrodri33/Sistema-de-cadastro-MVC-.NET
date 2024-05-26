using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Cp3_Cadastro.Models
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        [Key]
        public int id_endereco {  get; set; }

        [Required]
        public string? rua_endereco { get; set; }

        [Required]
        public int numero_endereco { get; set; }

        public string? complemento_endereco { get; set; }

        [Required]
        public string? bairro_endereco { get; set; }

        [Required]
        public string? cidade_endereco { get; set; }

        [Required]
        public string? estado_endereco { get; set; }

        [Required]
        public string? cep_endereco { get; set; }

        [ForeignKey("Pessoa")]
        public int id_pessoa { get; set; }
        public PessoaModel pessoa { get; set; }
    }
}
