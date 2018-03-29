using System;
using System.ComponentModel.DataAnnotations;

namespace Gourmet.Domain.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data de inclusão", Description = "Data de inclusão")]
        public DateTime DtInclusao { get; set; }
        [Display(Name = "Data de atualização", Description = "Data de atualização")]
        public DateTime? DtAtualizacao { get; set; }

        [Display(Name = "Observação", Description = "Observação")]
        public string Observacao { get; set; }

    }
}
