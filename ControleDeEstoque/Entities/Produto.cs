using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Marca { get; set; }

        [JsonIgnore]
        public List<Lote>? Lotes { get; set; }

        
    }
}
