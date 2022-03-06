using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using OLO.Comman.ApiResponse;
using OLO.Comman.DTOs;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface IorganizationRepository
{
        public  Task<ApiResponse> createOrganition(OrganizationModel organization);
        public  Task<ApiResponse> GetOrganizationList();
        public Task<ApiResponse> GetOrganizationById(int id);
        public Task<ApiResponse> updateOrganition(OrganizationModel organization);
        public Task<ApiResponse> login(LoginDto loginDto);
        public Task<ApiResponse> changePassword(ChangePasswordDto changePassword);
        //public Task<ApiResponse> addUser(UsersDto usersDto);
}
}
