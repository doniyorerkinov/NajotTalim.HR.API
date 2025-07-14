using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.API.Models;
using NajotTalim.HR.API.Services;

namespace NajotTalim.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;

        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            if (id == 0) return NotFound($"Employee with the given id: {id} not found.");
            else if (id < 0) return BadRequest("Wrong Data");
            return Ok(await _employeeSvc.Get(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createdEmployee = await _employeeSvc.Create(employee);
            var routeValue = new { id = createdEmployee.Id };
          return CreatedAtRoute(routeValue, createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
          var updatedEmployee = await  _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _employeeSvc.Delete(id);
            if(result)
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Employee with the given id: {id} not found.");
            }
        }
    }
}

/**
 IEmployeeRepository interfeysini EmployeeController ga dependency injection orqali inject qildik.
    IEmployeeRepository interfeysini MockEmployeeRepository orqali implement qildik.
Bu mahkap bog'lanish oldini oladi
 */