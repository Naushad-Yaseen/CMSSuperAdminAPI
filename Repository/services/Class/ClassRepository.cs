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
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse>getClassList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Class.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
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

        public async Task<ApiResponse> getClassById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Class.FirstOrDefaultAsync(x => x.ClassID==id && x.IsDeleted == false);
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

        public async Task<ApiResponse>classDropDownType()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Class.Where(x => x.IsActive == true && x.IsDeleted == false)
                        .Select(z => new classDropDown
                        {
                            ClassID = z.ClassID,
                            ClassName = z.ClassName,
                        }).ToListAsync();
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
        public async Task<ApiResponse> createClass(ClassModel classModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var isClassNameExist = await _context.Class.Where(x => (x.ClassName).ToLower() == classModel.ClassName.ToLower()).FirstOrDefaultAsync();
                var isClassCodeExist = await _context.Class.Where(x => x.ClassCode.ToLower() == classModel.ClassCode.ToLower()).FirstOrDefaultAsync();
                if (isClassNameExist==null && isClassCodeExist==null)
                {
                    var addclass = new Classess
                    {
                        ClassName = classModel.ClassName,
                        ClassCode = classModel.ClassCode,
                        StudentsLimit = classModel.StudentsLimit,
                        DepartmentID = classModel.DepartmentID,
                        IndexNo = classModel.IndexNo,
                        CreatedBy = Guid.NewGuid(),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.UtcNow

                    };
                    await _context.AddAsync(addclass);
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.Success;
                    response.Status = (int)Number.One;
                    response.ResponseData = addclass;
                }
                else if((isClassNameExist?.ClassName)?.ToLower()==classModel.ClassName.ToLower()&&
                    (isClassCodeExist?.ClassCode)?.ToLower() == classModel.ClassCode.ToLower())
                {
                    response.Message = ResponseMessage.ClassNameAndCodeExist;
                }
                else if((isClassNameExist?.ClassName)?.ToLower()==classModel.ClassName.ToLower()) {
                    response.Message = ResponseMessage.ClassNameExist;
                }
                else if((isClassCodeExist?.ClassCode).ToLower()==classModel.ClassCode.ToLower())
                {
                response.Message = ResponseMessage.ClassCodeExist;
                }


            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> UpdateClass(ClassModel classModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (classModel.ClassID != 0)
                {
                    var classess = await _context.Class.FirstOrDefaultAsync(x => x.ClassID == classModel.ClassID);
                    if (classess != null)
                    {
                        //department.DepartmentID = departmentModel.DepartmentID;
                        classess.ClassName = classModel.ClassName;
                        classess.ClassCode = classModel.ClassCode;
                        classess.StudentsLimit = classModel.StudentsLimit;
                        classess.ModifyBy = Guid.NewGuid();
                        classess.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                        response.ResponseData =classess;
                        // response.ResponseData = organization.OrganizationID;

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

        public async Task<ApiResponse> DeleteClass(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var classs = await _context.Class.FirstOrDefaultAsync(x => x.ClassID == id && x.IsDeleted == false);
                if (classs != null)
                {
                    classs.IsDeleted = true;
                    classs.DeletedDate = DateTime.UtcNow;
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
    }
}
