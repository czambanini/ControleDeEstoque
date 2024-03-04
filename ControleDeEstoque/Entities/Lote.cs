using ControleDeEstoque.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lote
    {
        public int Id { get; set; }
        public string? CodigoLote { get; set; }

        [JsonIgnore]
        public Produto? Produto { get; set; }
        public int Quantidade { set; get; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        public int idProduto { get; set; }

    }
}
