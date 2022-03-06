using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLO.Comman.DTOs;
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
    public class OrganizationController : ControllerBase
    {
        private readonly IorganizationRepository _iorganizationRepository;

        public OrganizationController(IorganizationRepository iorganizationRepository)
        {
            _iorganizationRepository = iorganizationRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _iorganizationRepository.login(loginDto);
            return Ok(result);
        }

        [HttpGet("GetOrganizationList")]

        public async Task<IActionResult> GetOrganizationList()
        {
            var result = await _iorganizationRepository.GetOrganizationList();
            return Ok(result);
        }
        [HttpGet("GetOrganizationById/{id}")]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            var result = await _iorganizationRepository.GetOrganizationById(id);
            return Ok(result);
        }

        [HttpPost("createOrganization")]
        public async Task<IActionResult>addOrganization(OrganizationModel organization)
        {
            var result = await _iorganizationRepository.createOrganition(organization);
            return Ok(result);
        }

        [HttpPost("updateOrganization")]
        public async Task<IActionResult> updateOrganization(OrganizationModel organization)
        {
            var result = await _iorganizationRepository.updateOrganition(organization);
            return Ok(result);
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> changePassword(ChangePasswordDto changePassword)
        {
            var result = await _iorganizationRepository.changePassword(changePassword);
            return Ok(result);
        }
    }
}
