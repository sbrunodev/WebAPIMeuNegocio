using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    public class Cliente : Pessoa
    {
        public Cliente()
        {
        }

        [Key]
        public int clienteId { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        
    }
}
