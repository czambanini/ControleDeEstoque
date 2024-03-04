using Domain.Entities;
using Infraestructure.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ControladorDeEstoqueContext : DbContext
    {
        //indica quais objetos vão ser mapeados como tabelas no banco
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        //conection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ControladorDeEstoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoteConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }


    }
}
