using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet.Domain.Models
{
    public class Usuario:EntityBase
    {
        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] SenhaCriptografada { get; set; }

        [NotMapped]
        public string Senha {
            get ;
            set;
        }
        [NotMapped]
        public string SenhaConfirmacao { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
