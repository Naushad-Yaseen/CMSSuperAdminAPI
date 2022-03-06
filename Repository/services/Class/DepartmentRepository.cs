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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> GetDepartmentIist()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Department.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
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

        public async Task<ApiResponse> GetDepartmentById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Department.FirstOrDefaultAsync(x => x.DepartmentID == id && x.IsDeleted == false);
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

        public async Task<ApiResponse> CreateDepartment(DepartmentModel departmentModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var isDepartmentNameExist = await _context.Department.Where(x => (x.DepartmentName).ToLower() == departmentModel.DepartmentName.ToLower()).FirstOrDefaultAsync();
                if (isDepartmentNameExist==null)
                {
                    var department = new Department
                    {
                        DepartmentName = departmentModel.DepartmentName,
                        AcademicSessionID = departmentModel.AcademicSessionID,
                        IndexNo = departmentModel.IndexNo,
                        CreatedBy = Guid.NewGuid(),
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = DateTime.UtcNow

                    };
                    _context.Add(department);
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.Success;
                    response.Status = (int)Number.One;
                    response.ResponseData = department.DepartmentID;

                }
                else
                {
                    response.Message = ResponseMessage.DepartmentExist;
                }
            

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> UpdateDepartment(DepartmentModel departmentModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (departmentModel.DepartmentID != 0)
                {
                    var department = await _context.Department.FirstOrDefaultAsync(x => x.DepartmentID == departmentModel.DepartmentID);
                    if (department != null)
                    {
                       
                        department.DepartmentName = departmentModel.DepartmentName;
                        department.AcademicSessionID = departmentModel.AcademicSessionID;
                        department.ModifyBy = Guid.NewGuid();
                        department.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                        response.ResponseData = department.DepartmentID;
                     

                    }
                    else
                    {
                        response.Status = (int)Number.Zero;
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

        public async Task<ApiResponse> DeleteDepartment(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var department = await _context.Department.FirstOrDefaultAsync(x => x.DepartmentID == id && x.IsDeleted == false);
                if (department != null)
                {
                    department.IsDeleted = true;
                    department.DeletedDate = DateTime.UtcNow;
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

        public async Task<ApiResponse> getDepartmentDropDown()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Department.Where(x => x.IsActive == true && x.IsDeleted == false)

                                    .Select(z => new departmentDropDown
                                    {
                                        DepartmentID = z.DepartmentID,
                                        DepartmentName = z.DepartmentName,
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
    }
}
