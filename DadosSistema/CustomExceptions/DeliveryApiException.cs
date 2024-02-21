using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.CustomExceptions
{
    public class DeliveryApiException : Exception
    {
        public int StatusCode { get; }
        public DeliveryApiException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
