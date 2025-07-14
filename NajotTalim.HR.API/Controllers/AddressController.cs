using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.API.Models;
using NajotTalim.HR.API.Services;

namespace NajotTalim.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;

        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return NotFound($"Address with the given id: {id} not found.");
            else if (id < 0) return BadRequest("Wrong Data");
            return Ok(await _addressSvc.Get(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createdAddress = await _addressSvc.Create(address);
            var routeValue = new { id = createdAddress.id };
            return CreatedAtRoute(routeValue, createdAddress);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedEmployee = await _addressSvc.Update(id, address);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _addressSvc.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Address with the given id: {id} not found.");
            }
        }
    }
}
