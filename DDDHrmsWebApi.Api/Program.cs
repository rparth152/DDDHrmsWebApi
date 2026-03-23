using DDDHrmsWebApi.Api.Middleware;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Application.Mapping;
using DDDHrmsWebApi.Infrastructure.Data;
using DDDHrmsWebApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure Serilog FIRST
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log.txt",
        rollingInterval: RollingInterval.Infinite,
        shared: true
    )
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDepartments, DepartmentService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<IDesignation, DesignationService>();
builder.Services.AddScoped<IEmployee, EmployeeService>();

builder.Services.AddAutoMapper(typeof(DTOMapping));


builder.Services.AddAuthentication("JwtBearer")
    .AddJwtBearer("JwtBearer", options =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// ✅ Authorization (MUST be before Build)
builder.Services.AddAuthorization();

var app = builder.Build();

// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // ✅ first
app.UseAuthorization();  // ✅ then

app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();

app.Run();