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
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        [HttpGet("GetSectionList")]
        public async Task<IActionResult> GetSectionList()
        {
            var result = await _sectionRepository.sectionList();
            return Ok(result);
        }
        
        [HttpGet("GetSectionDeopDown")]
        public async Task<IActionResult> GetSectionDeopDown()
        {
            var result = await _sectionRepository.getSectionDropDown();
            return Ok(result);
        }
        [HttpGet("GetSectionById/{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var result = await _sectionRepository.getsectionById(id);
            return Ok(result);
        }
        [HttpPost("addSection")]
        public async Task<IActionResult> addSection(SectionModel sectionModel)
        {
            var result = await _sectionRepository.createSection(sectionModel);
            return Ok(result);
        }

        [HttpPost("updateSection")]
        public async Task<IActionResult> updateSection(SectionModel sectionModel)
        {
            var result = await _sectionRepository.updateSection(sectionModel);
            return Ok(result);
        }

        [HttpDelete("deleteSection/{id}")]
        public async Task<IActionResult> deleteSection(int id)
        {
            var result = await _sectionRepository.deleteSection(id);
            return Ok(result);
        }
    }
}
