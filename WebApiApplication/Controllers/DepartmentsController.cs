using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public DepartmentsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDetails()
        {
            return await _dataContext.Departments.FromSql("GetDEpartmentDetails").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDetails(int id)
        {
            return await _dataContext.Departments.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostDetails([Bind("DepartmentName,DepartmentDescription")]
            Department department)
        {
            _dataContext.Database.ExecuteSqlCommand("DepartmentsSp @p0,@p1",department.DepartmentName,department.DepartmentDescription);

            await _dataContext.SaveChangesAsync();
            //return CreatedAtAction("", new {id = department.DepartmentId}, department);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> PutDetails(Department department)
        {
            IEnumerable<Department> existingDepartment = _dataContext.Departments.FromSql("GetDepartmentDetail @p0", department.DepartmentId);
            //var existingDepartment = _dataContext.Departments.FirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);
            if(existingDepartment != null)
            {
                foreach (var departments in existingDepartment)
                {
                    departments.DepartmentName = department.DepartmentName;
                    departments.DepartmentDescription = department.DepartmentDescription;
                }
            }
            else
            {
                return NotFound();
            }


            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> DeleteDetails(Department department)
        {
            //var details = await _dataContext.Departments.FindAsync(id);
            var details = _dataContext.Database.ExecuteSqlCommand("DeleteDepartment @p0", department.DepartmentId);
            if (details != 1)
            {
                return NotFound();
            }
            await _dataContext.SaveChangesAsync();
            return Ok();


        }
    }
}