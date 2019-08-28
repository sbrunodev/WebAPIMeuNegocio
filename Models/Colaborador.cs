using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMeuNegocio.Models
{
    [Table("Colaboradores")]
    public class Colaborador : Pessoa
    {
        public Colaborador()
        {
        }

        [Key]
        public int colaboradorId { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataAdmissao { get; set; } = DateTime.Now;
        public bool status { get; set; }
    }
}
