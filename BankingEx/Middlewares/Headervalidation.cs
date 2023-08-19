using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingEx.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Headervalidation
    {
        private readonly RequestDelegate _next;

        public Headervalidation(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string headervalue = httpContext.Request.Headers["Sec-Ch-Ua-Platform"][0];
            if(string.Compare(headervalue, "\"Windows\"", true)==0)
            {
                return _next(httpContext);

            }
            httpContext.Response.StatusCode = 401;
            return httpContext.Response.WriteAsync("Request cant Process");

           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HeadervalidationExtensions
    {
        public static IApplicationBuilder UseHeadervalidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Headervalidation>();
        }
    }
}
