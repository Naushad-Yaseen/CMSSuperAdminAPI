using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface IAcademicSessionRepository
    {
        public Task<ApiResponse> CreateAcademicSession(AcademicSessionDto academicSession);
        public Task<ApiResponse> AcademicSessionStatus();
        public  Task<ApiResponse> GetAacdemicSessionIist();
        public Task<ApiResponse> UpdateAcademicSession(AcademicSessionDto academicSession);
        public Task<ApiResponse> GetAacdemicSessionById(int id);
        public  Task<ApiResponse> DeleteAcademicSession(int id);
        public Task<ApiResponse> LockUnlockAcademicSession(int id);
        public Task<ApiResponse> AcademicSessionDropdown();
    }
}
