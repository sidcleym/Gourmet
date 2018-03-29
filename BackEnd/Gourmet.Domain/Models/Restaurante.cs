using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmet.Domain.Models
{
    public class Restaurante:EntityBase
    {
        public string Descricao { get; set; }

    }
}
