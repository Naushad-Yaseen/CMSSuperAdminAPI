using DataAcessLayer.DbContext;
using DataAcessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using Repository.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OLO.Comman.Enum.ResponseEnum;

namespace Repository.services.Class
{
    public class AcademicSessionRepository : IAcademicSessionRepository
    {
        private readonly AppDbContext _context;

        public AcademicSessionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> GetAacdemicSessionIist()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.AcademicSession.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
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

        public async Task<ApiResponse> GetAacdemicSessionById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.AcademicSession.FirstOrDefaultAsync(x => x.AcademicSessionID == id && x.IsDeleted == false);
                if (response.ResponseData != null)
                {
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;
                    response.Status = (int)Number.One;
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
        public async Task<ApiResponse> AcademicSessionStatus()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.AcademicSessionStatus.Where(x => x.IsActive == true && x.IsDeleted == false)
                    .Select(z => new AcademicSessionStatusDropDown
                    {
                        AcademicSessionStatusID = z.AcademicSessionStatusID,
                        AcademicSessionStatusName = z.AcademicSessionStatusName

                    }).ToListAsync();
                response.Status = (int)Number.One;
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.RecordsGet;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ApiResponse> AcademicSessionDropdown()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.AcademicSession.Where(x => x.IsActive == true && x.IsDeleted == false)
                    .Select(z => new AcademicSessionDropDown
                    {
                        AcademicSessionID = z.AcademicSessionID,
                        AcademicSessionName = z.AcademicSessionName

                    }).ToListAsync();
                response.Status = (int)Number.One;
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.RecordsGet;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> CreateAcademicSession(AcademicSessionDto academicSession)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var addAcademicSession = new AcademicSession
                {
                    AcademicSessionName = academicSession.AcademicSessionName,
                    StartDate = academicSession.StartDate,
                    EndDate = academicSession.EndDate,
                    AcademicSessionStatusID = academicSession.AcademicSessionStatusID,
                    CreatedBy = Guid.NewGuid(),
                    IsLocked = true,
                    LockedBy = academicSession.LockedBy,
                    LockedDate = academicSession.LockedDate,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.UtcNow

                };

                _context.Add(addAcademicSession);
                await _context.SaveChangesAsync();
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.Success;
                response.Status = (int)Number.One;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> UpdateAcademicSession(AcademicSessionDto academicSession)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (academicSession.AcademicSessionID != 0)
                {
                    var getacademicSession = await _context.AcademicSession.FirstOrDefaultAsync(x => x.AcademicSessionID == academicSession.AcademicSessionID);
                    if (getacademicSession != null)
                    {
                        getacademicSession.AcademicSessionID = academicSession.AcademicSessionID;
                        getacademicSession.AcademicSessionName = academicSession.AcademicSessionName;
                        getacademicSession.StartDate = academicSession.StartDate;
                        getacademicSession.EndDate = academicSession.EndDate;
                        getacademicSession.AcademicSessionStatusID = academicSession.AcademicSessionStatusID;
                        getacademicSession.ModifyBy = Guid.NewGuid();
                        getacademicSession.IsLocked = true;
                        getacademicSession.LockedBy = academicSession.LockedBy;
                        getacademicSession.LockedDate = academicSession.LockedDate;
                        // getacademicSession.IsActive = true;
                        // getacademicSession.IsDeleted = false;
                        getacademicSession.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                        response.ResponseData = academicSession.AcademicSessionID;


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

        public async Task<ApiResponse> DeleteAcademicSession(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var AcademicSession = await _context.AcademicSession.FirstOrDefaultAsync(x => x.AcademicSessionID == id && x.IsDeleted == false);
                if (AcademicSession != null)
                {
                    AcademicSession.IsDeleted = true;
                    AcademicSession.DeletedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordDeleted;
                    response.Status = (int)Number.One;

                }
                else
                {
                    response.Message = ResponseMessage.RecordNotFound;
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> LockUnlockAcademicSession(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var AcademicSession = await _context.AcademicSession.FirstOrDefaultAsync(x => x.AcademicSessionID == id && x.IsDeleted == false);
                if (AcademicSession != null)
                {
                    if (AcademicSession.IsLocked == true)
                    {
                        AcademicSession.IsLocked = false;
                        response.ResponseData = false;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.AcademicSessionUnlock;
                        response.Status = (int)Number.Zero;
                    }
                    else
                    {
                        AcademicSession.IsLocked = true;
                        response.ResponseData = true;
                        AcademicSession.LockedDate = DateTime.UtcNow;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.AcademicSessionlock;
                        response.Status = (int)Number.One;
                    }
                    await _context.SaveChangesAsync();


                }
                else
                {
                    response.Message = ResponseMessage.RecordNotFound;
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

    }
}
