﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.CustomExceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; }
        public ApiException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
