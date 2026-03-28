using AutoMapper;
using BCrypt.Net;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        IMapper mapper;

        public AuthService(ApplicationDbContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            this.mapper = mapper;
        }

        public async Task<string> Register(RegisterDTO dto)
        {
           
            var data =   mapper.Map<Employee>(dto);
            _context.Employee.Add(data);
            await _context.SaveChangesAsync();

            return "Registered Successfully";
        }

        public async Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            var user = _context.Employee.FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

            //if (dto.Password != user.Password)
            //{
            //    return null;
            //}

            var role = _context.AddRole.FirstOrDefault(r => r.RoleId == user.RoleId)?.RoleName;

            var token = GenerateToken(user.Email, role);

            return new AuthResponseDTO
            {
                Token = token,
                Role = role
            };
        }

        private string GenerateToken(string email, string role)
        {
            var claims = new List<Claim>()
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
