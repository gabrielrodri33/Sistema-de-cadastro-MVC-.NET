using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cp3_Cadastro.Models
{
    [Table("Pessoa")]
    public class PessoaModel
    {
        [Key]
        public int id_pessoa {  get; set; }

        [Required]
        public string? nome_pessoa { get; set; }

        [Required]
        public string? email_pessoa { get; set; }

        [Required]
        public string? senha_pessoa { get; set; }

        [Required]
        public string? cpf_pessoa {  get; set; }

        [InverseProperty("Pessoa")]
        public ICollection<EnderecoModel> enderecos { get; set; } = new List<EnderecoModel>();
    }
}
