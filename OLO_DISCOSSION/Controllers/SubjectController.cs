using Microsoft.AspNetCore.Mvc;
using OLO.ViewModels.Models;
using Repository.services.interfaces;
using System.Threading.Tasks;

namespace WEBOLO_DISCOSSION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet("getSubjectList")]
        public async Task<IActionResult> getSubjectList()
        {
            var result = await _subjectRepository.getSubjectList();
            return Ok(result);
        }
        
        [HttpGet("subjectDropDown")]
        public async Task<IActionResult> subjectDropDown()
        {
            var result = await _subjectRepository.getSubjectDropDown();
            return Ok(result);
        }
        [HttpGet("getSubjectById/{id}")]
        public async Task<IActionResult> getSubjectById(int id)
        {
            var result = await _subjectRepository.getSubjectById(id);
            return Ok(result);
        }

        [HttpDelete("deleteSubject/{id}")]
        public async Task<IActionResult> deleteSubject(int id)
        {
            var result = await _subjectRepository.deleteSubject(id);
            return Ok(result);
        }

        [HttpPost("addSubject")]

        public async Task<IActionResult> addSubject(SubjectModel subjectModel)
        {
            var result = await _subjectRepository.createSubject(subjectModel);
            return Ok(result);
        }

        [HttpPost("updateSubject")]

        public async Task<IActionResult> updateSubject(SubjectModel subjectModel)
        {
            var result = await _subjectRepository.updateSubject(subjectModel);
            return Ok(result);
        }
    }
}
