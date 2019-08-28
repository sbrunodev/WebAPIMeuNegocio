using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    public class Produto
    {
        [Key]
       
        public int produtoId { get; set; }

        [ForeignKey("categoriaid")]
        public int categoriaId { get; set; }

        public string descricao { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
        public decimal valorVenda { get; set; }

        public virtual Categoria categoria { get; set; }
    }
}
