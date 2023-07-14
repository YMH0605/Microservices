using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Recruiting.Core.Contracts.Repositories;
using Recruiting.Core.Contracts.Services;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repositories;
using Recruiting.Infrastructure.Services;
using RecruitingAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtTokenService();
builder.Services.AddCors(option =>
{

    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
var connectionString = Environment.GetEnvironmentVariable("RecDb");
connectionString = connectionString != null && connectionString.Length > 1 ? connectionString : builder.Configuration.GetConnectionString("RecDb");

builder.Services.AddDbContext<RecruitingDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //options.UseSqlServer(builder.Configuration.GetConnectionString("RecDb"));
    options.UseSqlServer(connectionString);
});
builder.Services.AddLogging();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();

builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();

builder.Services.AddScoped<ISubmissionStatusRepository, SubmissionStatusRepository>();
builder.Services.AddScoped<ISubmissionStatusService, SubmissionStatusService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.UseCors();
app.UseExceptionMiddleware();
app.MapControllers();

app.Run();
