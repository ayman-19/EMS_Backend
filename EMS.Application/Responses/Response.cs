﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EMS.Application.Responses
{
    public record Response
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyOrder(2)]
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyOrder(3)]
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
    public record ResponseOf<TResult> : Response
    {
        [JsonPropertyOrder(4)]
        [JsonPropertyName("result")]
        public TResult Result { get; set; }
    }
}
