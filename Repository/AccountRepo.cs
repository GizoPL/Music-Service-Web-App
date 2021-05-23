using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repository;
using Repository.Authentication;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly MusicContext _context;
        private readonly IPasswordHasher<Supplier> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountRepo(MusicContext context, IPasswordHasher<Supplier> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetSupplierById(int Id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(p => p.Id == Id);

            if (supplier is null)
            {
                throw new Exception("Supplier not found");
            }

            return supplier;
        }

        public void RegisterUser(Supplier registerSupplier)
        {
            var newSupplier = new Supplier()
            {
                UserName = registerSupplier.UserName,
                Email = registerSupplier.Email,
            };

            var hasedPassword = _passwordHasher.HashPassword(newSupplier, registerSupplier.Password);

            newSupplier.Password = hasedPassword;

            _context.Suppliers.Add(newSupplier);
        }

        public string GenerateJwt(LoginDto loginDto)
        {
            var supplier = _context.Suppliers.FirstOrDefault(x=>x.Email == loginDto.Email);

            if(supplier is null)
            {              
                throw new Exception("Invalid  user name or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(supplier, supplier.Password, loginDto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid  user name or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, supplier.Id.ToString()),
                new Claim(ClaimTypes.Name, supplier.UserName.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            
            return tokenHandler.WriteToken(token);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}