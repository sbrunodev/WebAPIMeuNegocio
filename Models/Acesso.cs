using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    public class Acesso
    {
        public string acessoId { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public DateTime ultimoLogin { get; set; } = DateTime.Now;

        public virtual Pessoa pessoa {get;set;}
    }
}
