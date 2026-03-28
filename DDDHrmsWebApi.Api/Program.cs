using DDDHrmsWebApi.Api.Middleware;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using DDDHrmsWebApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Logs
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt",
        rollingInterval: RollingInterval.Infinite)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskBoardService, TaskBoardService>();
builder.Services.AddScoped<IProjectEmp, ProjectEmpService>();
builder.Services.AddScoped<IProjectMang, ProjectMangService>();

//CORS tells browser: Yes Angular is allowed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseCors("AllowAngular");
app.MapControllers();

app.Run();
