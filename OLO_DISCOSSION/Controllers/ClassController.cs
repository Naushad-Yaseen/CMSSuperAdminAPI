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
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        [HttpGet("getClassList")]

        public async Task<IActionResult> getClassList()
        {
            var result = await _classRepository.getClassList();
            return Ok(result);
        }
        
        [HttpGet("getClassDropDown")]

        public async Task<IActionResult> getClassDropDown()
        {
            var result = await _classRepository.classDropDownType();
            return Ok(result);
        }

        [HttpGet("getClassById/{id}")]

        public async Task<IActionResult> getClassById(int id)
        {
            var result = await _classRepository.getClassById(id);
            return Ok(result);
        }

        [HttpPost("addClass")]

        public async Task<IActionResult> addClass(ClassModel classModel)
        {
            var result = await _classRepository.createClass(classModel);
            return Ok(result);
        }

        [HttpPost("updateClass")]

        public async Task<IActionResult> updateClass(ClassModel classModel)
        {
            var result = await _classRepository.UpdateClass(classModel);
            return Ok(result);
        }

        [HttpDelete("deleteClass/{id}")]

        public async Task<IActionResult> deleteClass(int id)
        {
            var result = await _classRepository.DeleteClass(id);
            return Ok(result);
        }
    }
}
