using Microsoft.EntityFrameworkCore;
using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Contracts.Services;
using Onboarding.Infrastructure.Data;
using Onboarding.Infrastructure.Repositories;
using Onboarding.Infrastructure.Services;
using OnboardingAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = Environment.GetEnvironmentVariable("RecDb");
builder.Services.AddDbContext<OnboardingDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RecDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddLogging();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();
builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

builder.Services.AddScoped<IEmployeeCategoryRepository, EmployeeCategoryRepository>();
builder.Services.AddScoped<IEmployeeCategoryService, EmployeeCategoryService>();

builder.Services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
builder.Services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseExceptionMiddleware();
app.Run();
