using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLO.ViewModels.Models;
using Repository.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBOLO_DISCOSSION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("DepartmentList")]
        public async Task<IActionResult> DepartmentList()
        {
            var result = await _departmentRepository.GetDepartmentIist();
            return Ok(result);
        } 
        
        [HttpGet("DepartmentDropDown")]
        public async Task<IActionResult> DepartmentDropDown()
        {
            var result = await _departmentRepository.getDepartmentDropDown();
            return Ok(result);
        }

        [HttpGet("DepartmentById/{id}")]
        public async Task<IActionResult> DepartmentById(int id)
        {
            var result = await _departmentRepository.GetDepartmentById(id);
            return Ok(result);
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentModel departmentModel)
        {
            var result = await _departmentRepository.CreateDepartment(departmentModel);
            return Ok(result);
        }

        [HttpPost("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentModel departmentModel)
        {
            var result = await _departmentRepository.UpdateDepartment(departmentModel);
            return Ok(result);
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentRepository.DeleteDepartment(id);
            return Ok(result);
        }
    }
}
