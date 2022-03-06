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
    public class AcademicSessionController : ControllerBase
    {
        private readonly IAcademicSessionRepository _academicSessionRepository;

        public AcademicSessionController(IAcademicSessionRepository academicSessionRepository)
        {
            _academicSessionRepository = academicSessionRepository;
        }

        [HttpGet("GetAcademicSessionList")]
        public async Task<IActionResult> GetAcademicSessionList()
        {
            var result = await _academicSessionRepository.GetAacdemicSessionIist();
            return Ok(result);
        }

        [HttpGet("GetAcademicSessionById/{id}")]
        public async Task<IActionResult> GetAcademicSessionById(int id)
        {
            var result = await _academicSessionRepository.GetAacdemicSessionById(id);
            return Ok(result);
        }

        [HttpGet("GetAcademicSessionStatus")]
        public async Task<IActionResult> GetAcademicSessionStatus()
        {
            var result = await _academicSessionRepository.AcademicSessionStatus();
            return Ok(result);
        } 
        
        [HttpGet("GetAcademicSessionDropDown")]
        public async Task<IActionResult> GetAcademicSessionDropDown()
        {
            var result = await _academicSessionRepository.AcademicSessionDropdown();
            return Ok(result);
        }
        [HttpPost("addAcademicSession")]
        public async Task<IActionResult> addAcademicSession(AcademicSessionDto academicSession)
        {
            var result = await _academicSessionRepository.CreateAcademicSession(academicSession);
            return Ok(result);
        }

        [HttpPost("updateAcademicSession")]
        public async Task<IActionResult> updateAcademicSession(AcademicSessionDto academicSession)
        {
            var result = await _academicSessionRepository.UpdateAcademicSession(academicSession);
            return Ok(result);
        }

        [HttpDelete("DeleteAcademicSession/{id}")]
        public async Task<IActionResult> DeleteAcademicSession(int id)
        {
            var result = await _academicSessionRepository.DeleteAcademicSession(id);
            return Ok(result);
        }

        [HttpGet("Lock/UnlockAcademicSession/{id}")]
        public async Task<IActionResult> LockUnlockAcademicSession(int id)
        {
            var result = await _academicSessionRepository.LockUnlockAcademicSession(id);
            return Ok(result);
        }
    }
}
