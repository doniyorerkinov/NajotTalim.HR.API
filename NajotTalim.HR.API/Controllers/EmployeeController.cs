using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.API.Models;
using System.Threading.Tasks;

namespace NajotTalim.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await MockEmployeeRepository.GetEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            if (id == 0) return NotFound($"Employee with the given id: {id} not found.");
            else if (id < 0) return BadRequest("Wrong Data");
            return Ok(await MockEmployeeRepository.GetEmployee(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var createdEmployee = await MockEmployeeRepository.CreateEmployee(employee);
            var routeValue = new { id = createdEmployee.Id };
          return CreatedAtRoute(routeValue, createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
