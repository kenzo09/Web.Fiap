using Fiap01.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeLogger(this IApplicationBuilder builder) => builder.UseMiddleware<LogMiddleware>();
    }
}
