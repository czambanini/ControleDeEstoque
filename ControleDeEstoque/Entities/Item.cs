using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque.Entities
{
    internal class Item
    {
        public Produto? Product { get; set; }
        public string? Lote { get; set; }
        public DateOnly Fabricacao { get; set; }
        public DateOnly Validade { get; set; }
    }
}
