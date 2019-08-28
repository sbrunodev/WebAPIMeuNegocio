using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    [Table("vendas")]
    public class Venda
    {
        public int vendaId { get; set; }
        public DateTime data { get; set; } = DateTime.Now;

        public decimal desconto { get; set; } = 0;
        public decimal totalBruto { get; set; }
        public decimal totalLiquido { get; set; }

        [ForeignKey("clienteId")]
        public int clienteId { get; set; }
        [ForeignKey("colaboradorId")]
        public int colaboradorId { get; set; }
        
        public virtual Cliente cliente { get; set; }
        public virtual Colaborador colaborador { get; set; }
        public ICollection<Item> itens { get; set; }
    }
}
