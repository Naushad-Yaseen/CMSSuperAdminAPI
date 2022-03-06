using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface IClassRepository
    {
        public Task<ApiResponse> createClass(ClassModel classModel);
        public Task<ApiResponse> getClassList();
        public Task<ApiResponse> getClassById(int id);
        public Task<ApiResponse> UpdateClass(ClassModel classModel);
        public Task<ApiResponse> DeleteClass(int id);
        public Task<ApiResponse> classDropDownType();
    }
}
