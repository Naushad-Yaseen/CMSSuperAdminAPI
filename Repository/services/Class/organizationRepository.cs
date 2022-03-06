using DataAcessLayer.DbContext;
using DataAcessLayer.Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OLO.Comman.ApiResponse;
using OLO.Comman.DTOs;
using OLO.ViewModels.Models;
using Repository.services.interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static OLO.Comman.Enum.ResponseEnum;

namespace Repository.services.Reppsitory
{
    public class organizationRepository : IorganizationRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public organizationRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ApiResponse> GetOrganizationList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Organization.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.RecordsGet;
                response.Status = (int)Number.One;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> GetOrganizationById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Organization.FirstOrDefaultAsync(x => x.OrganizationID == id);
                if (response.ResponseData != null)
                {
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;

                }
                else
                {
                    response.StatusCode = ResponseCode.NotFound;
                    response.Message = ResponseMessage.InvalidId;
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;

        }

        //public async Task<ApiResponse> createOrganition(Organization organization)
        public async Task<ApiResponse> createOrganition(OrganizationModel organization)
        {
            // int response = 0;
            ApiResponse response = new ApiResponse();
            try
            {
                var addOrganization = new Organization
                {
                    //OrganizationID = organization.OrganizationID,
                    OrganizationName = organization.OrganizationName,
                    OrganizationShortName = organization.OrganizationShortName,
                    ContactPersonFullName = organization.ContactPersonFullName,
                    Email = organization.Email,
                    ContactNumber = organization.ContactNumber,
                    ContactNumberCountryCode = organization.ContactNumberCountryCode,
                    UserName = organization.UserName,
                    Password = organization.Password,
                    SubDomainName = organization.SubDomainName,
                    OrganizationType = organization.OrganizationType,
                    MaximumStudentAllowed = organization.MaximumStudentAllowed,
                    ConnectionStringName = organization.ConnectionStringName,
                    OrganizationDatabaseName = organization.OrganizationDatabaseName,
                    CreatedBy = Guid.NewGuid(),
                    //IsEmailVerified = organization.IsEmailVerified,
                    IsEmailVerified = true,

                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.UtcNow

                };
                _context.Add(addOrganization);
                //await _context.SaveChangesAsync();
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.Success;
                response.Status = (int)Number.One;

                var addUser = new Users
                {
                    HasExcess = true,
                    RememberMe = true,
                    Password = organization.Password,
                    FirstName = organization.ContactPersonFullName,
                    LastName = organization.UserName,
                    UserName = organization.UserName,
                    Email = organization.Email,
                    PhoneNumber = organization.ContactNumber,
                    CreatedBy = Guid.NewGuid(),
                    RoleID = 1
                };
                _context.Add(addUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> updateOrganition(OrganizationModel organization)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (organization.OrganizationID != 0)
                {
                    var organizations = await _context.Organization.FirstOrDefaultAsync(x => x.OrganizationID == organization.OrganizationID);
                    if (organizations != null)
                    {
                        organizations.OrganizationID = organization.OrganizationID;
                        organizations.OrganizationName = organization.OrganizationName;
                        organizations.OrganizationShortName = organization.OrganizationShortName;
                        organizations.ContactPersonFullName = organization.ContactPersonFullName;
                        organizations.Email = organization.Email;
                        organizations.ContactNumber = organization.ContactNumber;
                        organizations.ContactNumberCountryCode = organization.ContactNumberCountryCode;
                        organizations.UserName = organization.UserName;
                        organizations.Password = organization.Password;
                        organizations.SubDomainName = organization.SubDomainName;
                        organizations.OrganizationType = organization.OrganizationType;
                        organizations.MaximumStudentAllowed = organization.MaximumStudentAllowed;
                        organizations.ConnectionStringName = organization.ConnectionStringName;
                        organizations.OrganizationDatabaseName = organization.OrganizationDatabaseName;
                        organizations.ModifyBy = Guid.NewGuid();

                        organizations.IsEmailVerified = true;

                        organizations.IsActive = true;
                        organizations.IsDeleted = false;
                        organizations.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                        response.ResponseData = organization.OrganizationID;

                    }
                    else
                    {
                        response.StatusCode = ResponseCode.NotFound;
                        response.Message = ResponseMessage.RecordNotFound;
                    }

                }
                else
                {
                    response.StatusCode = ResponseCode.NotFound;
                    response.Message = ResponseMessage.RecordNotFound;
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> changePassword(ChangePasswordDto changePassword)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var user = await _context.Organization.FirstOrDefaultAsync(x => x.OrganizationID == changePassword.OrganizationID);
                if (user !=null)
                {
                    user.OrganizationID = changePassword.OrganizationID;
                    user.Password = changePassword.newPassword;
                    await _context.SaveChangesAsync();
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.ResetPassword;
                }
                else
                {
                    response.StatusCode = ResponseCode.NotFound;
                    response.Message = ResponseMessage.RecordNotFound;
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ApiResponse> login(LoginDto loginDto)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == loginDto.Email.ToLower());
                //_userManager.FindByNameAsync(request.Email);
                if (user == null)
                {

                    response.StatusCode = ResponseCode.BadRequest;
                    response.Message = ResponseMessage.UserNotExist;
                    return response;
                }
                //var passwordLength = user.Password;
                // if (!string.Equals(SecurityManager.ComputeSha512Hash(loginDto.Password), user.Password))
                if (!string.Equals(loginDto.Password, user.Password))
                {

                    response.StatusCode = ResponseCode.BadRequest;
                    response.Message = ResponseMessage.PasswordError;
                    return response;
                }
                var orgDetails = await _context.Organization.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
                if (orgDetails == null)
                {
                    response.StatusCode = ResponseCode.BadRequest;
                    response.Message = ResponseMessage.RecordNotFound;
                    return response;
                }
                //var userDetails = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
                var userDetails = await _context.Users
                                       .Join(_context.Role,
                                           u => u.RoleID,
                                           r => r.RoleID,
                                           (u, r) => new { u, r })
                                       .Where(z => z.u.Email == loginDto.Email)
                                       .FirstOrDefaultAsync();

              

                if (orgDetails.IsEmailVerified == false)
                {
                    response.StatusCode = ResponseCode.BadRequest;
                   // response.Message = ResponseMessage.FirstEmailConfirmDetails;
                    response.Message = ResponseMessage.FirstEmailConfirmDetails;
                    return response;
                }

                #region commented Token Generation Code
                //string DecryptionPassword = SecurityManager.DecodeBase64(user.Password);
                //string password = SecurityManager.EncodeBase64(request.Password);
                //var roles = await _context.AspNetRoles.FirstOrDefaultAsync(x => x.RoleID == user.RoleID);

                //var claims = new List<Claim>
                //    {
                //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //        new Claim(JwtRegisteredClaimNames.Email, user.Username),
                //        //new Claim(JwtRegisteredClaimNames.GivenName, orgDetails.OrganizationName),
                //        //new Claim(JwtRegisteredClaimNames.FamilyName, orgDetails.ContactPersonFullName),
                //        new Claim(JwtRegisteredClaimNames.Sub, "Admin"),
                //    };
                //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                //var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                //  _configuration["Jwt:Issuer"],
                //  null,
                //  expires: DateTime.Now.AddDays(7),
                //  signingCredentials: credentials);

                //string encodedJwtAccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, userDetails.u.UserID.ToString()),
                        new Claim(JwtRegisteredClaimNames.FamilyName, userDetails.u.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, userDetails.u.Email),
                        new Claim(JwtRegisteredClaimNames.GivenName, orgDetails.OrganizationName),
                        new Claim(JwtRegisteredClaimNames.Iss, orgDetails.OrganizationID.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sid, !string.IsNullOrEmpty(userDetails.r.RoleID.ToString()) ? userDetails.r.RoleID.ToString() : string.Empty),
                        new Claim(JwtRegisteredClaimNames.Sub, "Admin"),
                    }),

                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha256Signature),
                    Audience = _configuration["Jwt:Issuer"]
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                string encodedJwtAccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                LoginResponseDto loginnDto = new LoginResponseDto()
                {
                    RoleID = 1,
                    Email = orgDetails.Email,
                    FullName = orgDetails.ContactPersonFullName,
                    RoleName = "Admin",
                    UserID = user.UserID,
                    Token = encodedJwtAccessToken,
                    Username = user.UserName,
                    OrganizationID = orgDetails.OrganizationID,
                    ContactNumber = orgDetails.ContactNumberCountryCode + orgDetails.ContactNumber,
                    OrganizationName = orgDetails.OrganizationName,
                };
                response.Status = 200;
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.LogSuccess;
                response.ResponseData = loginnDto;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
