using Interview.Core.Contracts.Repositories;
using Interview.Core.Contracts.Services;
using Interview.Infrastructure.Data;
using Interview.Infrastructure.Repositories;
using Interview.Infrastructure.Services;
using InterviewAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using JWTAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtTokenService();
var connectionString = Environment.GetEnvironmentVariable("RecDb");
connectionString = connectionString != null && connectionString.Length > 1 ? connectionString : builder.Configuration.GetConnectionString("RecDb");
builder.Services.AddDbContext<InterviewEFDbContext>(options =>
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
builder.Services.AddSingleton(new InterviewDbContext(connectionString));
builder.Services.AddLogging();
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewService, InterviewService>();

builder.Services.AddScoped<IInterviewFeedbackRepository, InterviewFeedbackRepository>();
builder.Services.AddScoped<IInterviewFeedbackService, InterviewFeedbackService>();

builder.Services.AddScoped<IInterviewerRepository, InterviewerRepository>();
builder.Services.AddScoped<IInterviewerService, InterviewerService>();

builder.Services.AddScoped<IInterviewTypeRepository, InterviewTypeRepository>();
builder.Services.AddScoped<IInterviewTypeService, InterviewTypeService>();

builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
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
app.UseExceptionMiddleware();
app.MapControllers();

app.Run();
