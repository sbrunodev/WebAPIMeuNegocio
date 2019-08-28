using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMeuNegocio.Models;

namespace WebAPIMeuNegocio.Models
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<WebAPIMeuNegocio.Models.Venda> Venda { get; set; }
    }
}