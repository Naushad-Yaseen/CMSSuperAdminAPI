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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> createSubject(SubjectModel subjectModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var isSubjectCodeExist = await _context.Subject.Where(x => (x.SubjectCode).ToLower() == subjectModel.SubjectCode.ToLower()).FirstOrDefaultAsync();
                var isSubjectNameExist = await _context.Subject.Where(x => (x.SubjectName).ToLower() == subjectModel.SubjectName.ToLower()).FirstOrDefaultAsync();
                if (isSubjectCodeExist == null && isSubjectNameExist == null)
                {
                    var subject = new Subject
                    {
                        SubjectName = subjectModel.SubjectName,
                        SubjectCode = subjectModel.SubjectCode,
                        SubjectCredit = subjectModel.SubjectCredit,
                        //IsCore = subjectModel.IsCore,
                        IsCore = true,
                        ClassID = subjectModel.ClassID,
                        SectionID = subjectModel.SectionID,
                        IndexNo = subjectModel.IndexNo,
                        SubjectEnrollmentStatusID = subjectModel.SubjectEnrollmentStatusID,
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true,
                        IsDeleted = false,
                    };
                    await _context.AddAsync(subject);
                    await _context.SaveChangesAsync();
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.Success;
                }

                else if ((isSubjectNameExist?.SubjectName)?.ToLower() == subjectModel.SubjectName.ToLower() &&
                    (isSubjectCodeExist?.SubjectCode)?.ToLower() == subjectModel.SubjectCode.ToLower())
                {
                    response.Message = ResponseMessage.SubjectCodeAndSubjectNameExist;

                }

                else if ((isSubjectCodeExist?.SubjectCode)?.ToLower() == subjectModel.SubjectCode.ToLower())
                {
                    response.Message = ResponseMessage.SubjectCodeExist;
                }

                else if ((isSubjectNameExist?.SubjectName)?.ToLower() == subjectModel.SubjectName.ToLower())
                {
                    response.Message = ResponseMessage.SubjectNameExist;
                }


            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> deleteSubject(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var subject = await _context.Subject.Where(x => x.SubjectID == id && x.IsDeleted == false).FirstOrDefaultAsync();
                if (subject != null)
                {
                    subject.IsDeleted = true;
                    subject.DeletedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordDeleted;
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

        public async Task<ApiResponse> getSubjectById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Subject.Where(x => x.SubjectID == id && x.IsDeleted == false).FirstOrDefaultAsync();
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

        public async Task<ApiResponse> getSubjectList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Subject.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
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

        public async Task<ApiResponse> getSubjectDropDown()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Subject.Where(x => x.IsActive == true && x.IsDeleted == false)
                    .Select(z => new subjectDropDown
                    {
                        SubjectID = z.SubjectID,
                        SubjectName = z.SubjectName,
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

        public async Task<ApiResponse> updateSubject(SubjectModel subjectModel)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                if (subjectModel.SubjectID != 0)
                {
                    var subject = await _context.Subject.Where(x => x.SubjectID == subjectModel.SubjectID).FirstOrDefaultAsync();
                    if (subject != null)
                    {
                        subject.SubjectID = subjectModel.SubjectID;
                        subject.SubjectName = subjectModel.SubjectName;
                        subject.SubjectCode = subjectModel.SubjectCode;
                        subject.SubjectCredit = subjectModel.SubjectCredit;
                        subject.IsCore = subjectModel.IsCore;
                        subject.SectionID = subjectModel.SectionID;
                        subject.ClassID = subjectModel.ClassID;
                        subject.IndexNo = subjectModel.IndexNo;
                        subject.SubjectEnrollmentStatusID = subjectModel.SubjectEnrollmentStatusID;
                        subject.ModifyBy = Guid.NewGuid();
                        subject.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        apiResponse.Status = (int)Number.One;
                        apiResponse.StatusCode = ResponseCode.Ok;
                        apiResponse.Message = ResponseMessage.UpdateSuccess;

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
    }
}
