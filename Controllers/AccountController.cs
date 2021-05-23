using System.Collections.Generic;
using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Model;
using Repository;

namespace Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepo _repository;

        public AccountController(IMapper mapper, IAccountRepo repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("getSupplier/{id}", Name = "GetSupplier")]
        public ActionResult<SupplierReadDto> GetSupplier(int id)
        {
            var supplier = _repository.GetSupplierById(id);
            
            if(supplier is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierReadDto>(supplier));
        }

        [HttpGet("getAllSuppliers")]
        public ActionResult<IEnumerable<SupplierReadDto>> GetAllSupplier()
        {
            var suppliers = _repository.GetAllSuppliers();

            return Ok(_mapper.Map<IEnumerable<SupplierReadDto>>(suppliers));
        }

        [HttpPost("register")]
        public ActionResult RegisterUser(SupplierRegisterDto supplierRegisterDto)
        {
            var registerSupplier = _mapper.Map<Supplier>(supplierRegisterDto);

            _repository.RegisterUser(registerSupplier);

            _repository.SaveChanges();

            var createdSupplier = _mapper.Map<SupplierReadDto>(registerSupplier);

            return CreatedAtRoute(nameof(GetSupplier), new {Id = createdSupplier.Id}, supplierRegisterDto);
        }


    }
}