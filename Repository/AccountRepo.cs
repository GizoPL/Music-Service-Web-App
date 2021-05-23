using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repository;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly MusicContext _context;
        private readonly IPasswordHasher<Supplier> _passwordHasher;

        public AccountRepo(MusicContext context, IPasswordHasher<Supplier> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}