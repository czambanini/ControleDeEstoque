using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class ProdutoVencidoException : Exception
    {
        public int StatusCode { get; }

        public ProdutoVencidoException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
