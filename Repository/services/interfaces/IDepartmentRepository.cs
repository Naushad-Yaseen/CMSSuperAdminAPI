using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface IDepartmentRepository
    {
        public Task<ApiResponse> CreateDepartment(DepartmentModel departmentModel);
        public Task<ApiResponse> UpdateDepartment(DepartmentModel departmentModel);
        public Task<ApiResponse> GetDepartmentIist();
        public Task<ApiResponse> GetDepartmentById(int id);
        public Task<ApiResponse> DeleteDepartment(int id);
        public Task<ApiResponse> getDepartmentDropDown();
    }
}
