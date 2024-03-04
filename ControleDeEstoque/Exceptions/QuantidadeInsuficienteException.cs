using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class QuantidadeInsuficienteException : Exception
    {
        public int StatusCode { get; }

        public QuantidadeInsuficienteException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

    }
}
