using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _cargoCustomerService = customerService;
        }
        [HttpGet]
        public IActionResult GetCargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                SurName = createCargoCustomerDto.SurName,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Address = createCargoCustomerDto.Address
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Müşterisi Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşterisi Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                SurName = updateCargoCustomerDto.SurName,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Address = updateCargoCustomerDto.Address
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşterisi Başarıyla Güncellendi");
        }
    }
}
