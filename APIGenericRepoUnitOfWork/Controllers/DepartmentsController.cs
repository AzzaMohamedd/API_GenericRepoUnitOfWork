using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGenericRepoUnitOfWork.Models;
using APIGenericRepoUnitOfWork.DTO;
using APIGenericRepoUnitOfWork.Models;
using APIGenericRepoUnitOfWork.Repositories;
using APIGenericRepoUnitOfWork.UnitOfWorks;

namespace APIGenericRepoUnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        UnitOfWork unit;
        public DepartmentsController(UnitOfWork unit)
        {
            this.unit = unit;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult GetDepartments()
        {
            var depts = unit.DeptGenRepo.GetAll();

            if (depts == null) return NotFound();
            else
            {
                List<DepartmentDTO> deptsDTO = new List<DepartmentDTO>();
                foreach (var dept in depts)
                {
                    DepartmentDTO depDTO = new DepartmentDTO()
                    {
                        ID = dept.Dept_Id,
                        Name = dept.Dept_Name,
                        Description = dept.Dept_Desc,
                        Location = dept.Dept_Location,
                        Dept_Manager = dept.Dept_Manager,
                        NumOfStudents = dept.Students.Count()
                    };
                    deptsDTO.Add(depDTO);
                }
                return Ok(deptsDTO);
            }
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult GetDepartmentByID(int id)
        {
            var department = unit.DeptGenRepo.GetByID(id);

            if (department == null)
            {
                return NotFound();
            }
            else
            {
                DepartmentDTO depDTO = new DepartmentDTO()
                {
                    ID = department.Dept_Id,
                    Name = department.Dept_Name,
                    Description = department.Dept_Desc,
                    Location = department.Dept_Location,
                    Dept_Manager = department.Dept_Manager,
                    NumOfStudents = department.Students.Count()
                };
                return Ok(depDTO);
            }
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult EditDepartment(int id, Department department)
        {
            if (id != department.Dept_Id) return BadRequest();
            if (department == null) return NotFound();

            unit.DeptGenRepo.Update(department);
            unit.Save();

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            if (department == null) return BadRequest();
            else
            {
                unit.DeptGenRepo.Add(department);
                unit.Save();

                return CreatedAtAction("GetDepartmentByID", new { id = department.Dept_Id }, department);
            }
        }
        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = unit.DeptGenRepo.GetByID(id);
            if (department == null)
            {
                return NotFound();
            }

            unit.DeptGenRepo.Delete(department);
            unit.Save();

            return Ok(department);
        }
    }
}
