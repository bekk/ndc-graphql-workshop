using System;
using Microsoft.AspNetCore.Http;

namespace GraphQLServer
{
    public class GraphQLSettings
    {
        public PathString Path { get; set; } = "/";
        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}