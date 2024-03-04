using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class ProdutoRequestcs
    {
        [Required]
        public string? Nome { get; set; }
        public string? Marca { get; set; }

    }
}
