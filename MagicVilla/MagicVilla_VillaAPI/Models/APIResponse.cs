﻿using Azure.Core.Pipeline;
using System.Net;

namespace MagicVilla_VillaAPI.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMassages = new List<string>();    
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMassages { get; set; }

        public object Result { get; set; }
    }
}
