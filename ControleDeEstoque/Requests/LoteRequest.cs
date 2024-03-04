using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class LoteRequest
    {
        [Required]
        public string? CodigoLote { get; set; }

        [Required]
        public int idProduto { get; set; }

        [Required]
        public int Quantidade { set; get; }

        public DateTime Fabricacao { get; set; }

        [Required]
        public DateTime Validade { get; set; }
        

    }
}
