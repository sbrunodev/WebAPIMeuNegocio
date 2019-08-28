using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    [Table("itens")]
    public class Item
    {       
        public int itemId { get; set; }

        [ForeignKey("produtoId")]
        public int produtoId { get; set; }
        
        public decimal quantidade { get; set; }
        public decimal valorunitario { get; set; }
        public decimal total { get; set; }

        public virtual Produto produto { get; set; }
    }
}
