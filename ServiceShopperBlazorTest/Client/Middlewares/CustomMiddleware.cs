﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceShopperBlazorTest.Shared.MiddlewareRequestAssigment;

namespace ServiceShopperBlazorTest.Client.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        HttpRequestAssigmentExecutioner assignmentExecutioner;

        public CustomMiddleware(RequestDelegate next, HttpRequestAssigmentExecutioner assigmentExecutioner)
        {
            _next = next;
            this.assignmentExecutioner = assignmentExecutioner;
        }

        public Task Invoke(HttpContext httpContext)
        {
            assignmentExecutioner.ExecuteAllAssigments(ref httpContext);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
