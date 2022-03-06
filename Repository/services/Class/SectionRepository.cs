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
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse>sectionList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Section.Where(x => x.IsDeleted == false).ToListAsync();
                response.Status = (int)Number.One;
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.RecordsGet;

            }
            catch (Exception ex)
            {

                response.Message=ex.Message;
            }
            return response;
        }


        public async Task<ApiResponse>getSectionDropDown()
        {
            ApiResponse res = new ApiResponse();
            try
            {
                res.ResponseData = await _context.Section.Where(x => x.IsActive == true && x.IsDeleted == false)
                                    .Select(z => new sectionDropDown
                                    {
                                        SectionID = z.SectionID,
                                        SectionName = z.SectionName,
                                    }).ToListAsync();
                res.Status = (int)Number.One;
                res.StatusCode = ResponseCode.Ok;
                res.Message = ResponseMessage.RecordsGet;
            }
            catch (Exception ex)
            {

                res.Message = ex.Message;
            }
            return res;

        }

        public async Task<ApiResponse> getsectionById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Section.FirstOrDefaultAsync(x => x.SectionID == id && x.IsDeleted == false);
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

        public async Task<ApiResponse> createSection(SectionModel sectionModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var section = new Section
                {
                    SectionName = sectionModel.SectionName,
                    SectionCode = sectionModel.SectionCode,
                    StudentsLimit = sectionModel.StudentsLimit,
                    ClassID = sectionModel.ClassID,
                    IndexNo = sectionModel.IndexNo,
                    CreatedBy = Guid.NewGuid(),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.UtcNow
                };
                await _context.AddAsync(section);
                await _context.SaveChangesAsync();
                response.StatusCode = ResponseCode.Ok;
                response.Message = ResponseMessage.Success;
                response.Status = (int)Number.One;
                response.ResponseData = section.SectionID;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> updateSection(SectionModel sectionModel)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                if (sectionModel.SectionID != 0)
                {
                    var section = await _context.Section.Where(x => x.SectionID == sectionModel.SectionID).FirstOrDefaultAsync();
                    if (section != null)
                    {
                        section.SectionID = sectionModel.SectionID;
                        section.SectionName = sectionModel.SectionName;
                        section.SectionCode = sectionModel.SectionCode;
                        section.StudentsLimit = sectionModel.StudentsLimit;
                        section.ClassID = sectionModel.ClassID;
                        section.IndexNo = sectionModel.IndexNo;
                        section.ModifyBy = Guid.NewGuid();
                        section.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        apiResponse.Status = (int)Number.One;
                        apiResponse.StatusCode = ResponseCode.Ok;
                        apiResponse.Message = ResponseMessage.UpdateSuccess;
                       // apiResponse.ResponseData = section;
                    }
                    else
                    {
                        apiResponse.Status = (int)Number.Zero;
                        apiResponse.StatusCode = ResponseCode.NotFound;
                        apiResponse.Message = ResponseMessage.RecordNotFound;
                    }
                }
                else
                {
                    apiResponse.StatusCode = ResponseCode.NotFound;
                    apiResponse.Message = ResponseMessage.RecordNotFound;
                }

            }
            catch (Exception ex)
            {

                apiResponse.Message = ex.Message;
            }
            return apiResponse;
        }

        public async Task<ApiResponse>deleteSection(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var section = await _context.Section.FirstOrDefaultAsync(x => x.SectionID == id & x.IsDeleted == false);
                    if (section!=null)
                {
                    section.IsDeleted = true;
                    section.DeletedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordDeleted;
                    response.Status = (int)Number.One;
                    response.ResponseData = section.SectionID;
                }
                else
                {
                    response.Status = (int)Number.Zero;
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
