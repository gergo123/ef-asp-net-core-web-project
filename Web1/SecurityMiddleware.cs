using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Db3.Repositories.RLS;
using Db3.RLS;

namespace Web1
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;

        private SecurityIdentityRepository RlsIdentityRepo;
        private CurrentUserProvider CurrentUser;
        private readonly ILogger _logger;
        private PermissionService PermissionService;

        public SecurityMiddleware(RequestDelegate next, ILogger<SecurityMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.0&tabs=aspnetcore2x#per-request-dependencies
        public async Task Invoke(HttpContext context, CurrentUserProvider currentUser,
            SecurityIdentityRepository rlsRepo, PermissionService permissionService)
        {
            RlsIdentityRepo = rlsRepo;
            PermissionService = permissionService;

            CurrentUser = currentUser;
            var userName = context.User.Identity.Name;

            _logger.LogInformation($"Invoke - {userName}");

			RegisterUser(userName);

            await _next(context);
        }
        
        private void RegisterUser(string identifier)
        {
            CurrentUser.SetIdentifier(identifier);
            var identity = PermissionService.RegisterUserIfNotExists(identifier);
            CurrentUser.SetUser(identity);
        }
    }
}
