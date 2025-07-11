﻿using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.API.Models;
using System.Threading.Tasks;

namespace NajotTalim.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeRepository.GetEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Get(int id)
        {
            if (id == 0) return NotFound($"Employee with the given id: {id} not found.");
            else if (id < 0) return BadRequest("Wrong Data");
            return Ok(await _employeeRepository.GetEmployee(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var createdEmployee = await _employeeRepository.CreateEmployee(employee);
            var routeValue = new { id = createdEmployee.Id };
          return CreatedAtRoute(routeValue, createdEmployee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
          var updatedEmployee = await  _employeeRepository.UpdateEmployee(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _employeeRepository.DeleteEmployee(id);
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