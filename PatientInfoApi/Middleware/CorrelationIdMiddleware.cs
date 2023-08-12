﻿namespace PatientInfoApi.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("X-Correlation-ID"))
            {
                context.Request.Headers.Add("X-Correlation-ID", Guid.NewGuid().ToString());
            }

            await _next(context);
        }
    }
}
