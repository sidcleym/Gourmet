using System.ComponentModel.DataAnnotations;

namespace Gourmet.Domain.Models
{
    public class Prato:EntityBase
    {

        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

    }
}
