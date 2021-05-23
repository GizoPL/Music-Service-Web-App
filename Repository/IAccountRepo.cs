using System.Collections.Generic;
using Dtos;
using MyFirstWebApp.Model;

namespace Repository
{
    public interface IAccountRepo
    {
        bool SaveChanges();
        void RegisterUser(Supplier supplier);

        Supplier GetSupplierById(int Id);
        IEnumerable<Supplier> GetAllSuppliers();
        string GenerateJwt(LoginDto loginDto);
    }
}