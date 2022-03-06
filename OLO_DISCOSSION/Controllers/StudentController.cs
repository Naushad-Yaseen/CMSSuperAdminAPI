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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet("getStudent")]
        public async Task<IActionResult> getStudent()
        {
            var result = await _studentRepository.getStudentList();
            return Ok(result);
        }

        [HttpGet("getStudentParent")]
        public async Task<IActionResult> getStudentParent()
        {
            var result = await _studentRepository.getStudentParentList();
            return Ok(result);
        }

        [HttpGet("getSectionByClassId/{id}")]
        public async Task<IActionResult> getSectionByClassId(int id)
        {
            var result = await _studentRepository.GetSectionByClassId(id);
            return Ok(result);
        }

        [HttpGet("getStudentParentById/{id}")]
        public async Task<IActionResult> getStudentParentById(int id)
        {
            var result = await _studentRepository.getStudentParentById(id);
            return Ok(result);
        } 
        
        [HttpGet]
        [ActionName("getStudentDetailsByClassIdSectionIdAcademicId")]
        public async Task<IActionResult> getStudentDetailsByClassIdSectionIdAcademicId(int AcademicSessionID, int ClassID, int SectionID)
        {
            var result = await _studentRepository.getStudentDetailsByClassIdSectionIdAcademicId(AcademicSessionID, ClassID, SectionID);
            return Ok(result);
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> addStudent(StudentModel studentModel)
        {
            var result = await _studentRepository.createStudent(studentModel);
            return Ok(result);
        }

        [HttpPost("updateStudent")]
        public async Task<IActionResult> updateStudent(StudentModel studentModel)
        {
            var result = await _studentRepository.updateStudent(studentModel);
            return Ok(result);
        }

        [HttpDelete("deleteStudent/{id}")]
        public async Task<IActionResult> deleteStudent(int id)
        {
            var result = await _studentRepository.deleteStudent(id);
            return Ok(result);
        }
    }
}
