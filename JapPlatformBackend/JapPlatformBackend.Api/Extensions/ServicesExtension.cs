using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Repositories;
using JapPlatformBackend.Services;

namespace JapPlatformBackend.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IProgramService, ProgramService>();
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<ISelectionService, SelectionService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAdminService, AdminService>();
            service.AddTransient<IMailService, MailService>();

            service.AddTransient<ISelectionRepository, SelectionRepository>();
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient<IProgramRepository, ProgramRepository>();
        }
    }
}
