using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet.Domain.Models
{
    public class Prato:EntityBase
    {

        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        [ForeignKey("Restaurante")]
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; }

    }
}
