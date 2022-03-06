using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
    public interface IStudentRepository
    {
        public Task<ApiResponse> getStudentList();
        //public Task<ApiResponse> getStudentById(int id);
        public Task<ApiResponse> createStudent(StudentModel studentModel);
        public Task<ApiResponse> updateStudent(StudentModel studentModel);
        public Task<ApiResponse> deleteStudent(int id);
        public Task<ApiResponse> getStudentParentList();
        public Task<ApiResponse> getStudentParentById(int id);
        public Task<ApiResponse> GetSectionByClassId(int classId);
        public  Task<ApiResponse> getStudentDetailsByClassIdSectionIdAcademicId(int AcademicSessionID, int ClassID, int SectionID);
    }
}
