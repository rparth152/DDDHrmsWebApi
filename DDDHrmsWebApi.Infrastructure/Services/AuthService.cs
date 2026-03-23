using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> Register(RegisterDTO dto)
        {
            var user = new Employee
            {
                FirstName = dto.FirstName ?? "NA",
                LastName = dto.LastName ?? "NA",
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),

                JoiningDate = DateTime.Now,
                //BirthDate = dto.BirthDate ?? DateTime.Now,

                DepartmentId = dto.DepartmentId,
                RoleId = dto.RoleId,
                DesignationId = dto.DesignationId,

                ContactNumber = dto.ContactNumber ?? "0000000000",
                Address = dto.Address ?? "NA",
                Gender = dto.Gender ?? "NA",

                Status = "Active",
                About = "New Employee"
            };

            _context.Employee.Add(user);
            await _context.SaveChangesAsync();

            return "Registered Successfully";
        }

        public async Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            var user = _context.Employee
                .FirstOrDefault(x => x.Email == dto.Email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return null;
            }

            var role = _context.AddRole
                .FirstOrDefault(r => r.RoleId == user.RoleId)?.RoleName;

            var token = GenerateToken(user.Email, role);

            return new AuthResponseDTO
            {
                Token = token,
                Role = role
            };
        }

        private string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role)
             };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
