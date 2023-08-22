using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

public class RoleAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public RoleAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IAuthenticationService authService)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var user = context.User;
            var requiredRoles = context.Request.Method switch
            {
                "GET" => new[] { "Teacher", "Student", "Admin" },
                "POST" => new[] { "Teacher", "Admin" },
                "PUT" => new[] { "Teacher", "Admin" },
                "DELETE" => new[] { "Teacher", "Admin" },
                _ => Array.Empty<string>()
            };

            foreach (var role in requiredRoles)
            {
                if (user.IsInRole(role))
                {
                    await _next.Invoke(context);
                    return;
                }
            }

            context.Response.StatusCode = 403; // Forbidden
            return;
        }

        await _next.Invoke(context);
    }
}
