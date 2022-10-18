using JapPlatformBackend.Api.Extensions;
using JapPlatformBackend.Api.Middleware;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

builder.Services.RegisterControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwagger();

builder.Services.RegisterServices();

builder.Services.RegisterAutomapperProfiles();

builder.Services.RegisterValidators();

builder.Services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>();

builder.Services.RegisterIdentity();

builder.Services.RegisterAuthentication(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.SetupCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseMiddleware<ExceptionHandler>();

app.UseMiddleware<AntiXssMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
