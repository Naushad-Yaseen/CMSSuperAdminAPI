using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface ISubjectRepository
    {
        public Task<ApiResponse> getSubjectList();
        public Task<ApiResponse> getSubjectById(int id);
        public Task<ApiResponse> createSubject(SubjectModel subjectModel);
        public Task<ApiResponse> updateSubject(SubjectModel subjectModel);
        public Task<ApiResponse> deleteSubject(int id);

        public Task<ApiResponse> getSubjectDropDown();
    }
}
