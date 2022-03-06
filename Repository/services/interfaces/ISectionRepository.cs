using OLO.Comman.ApiResponse;
using OLO.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.services.interfaces
{
   public interface ISectionRepository
    {
        public  Task<ApiResponse> sectionList();
        public Task<ApiResponse> getsectionById(int id);
        public  Task<ApiResponse> createSection(SectionModel sectionModel);
        public Task<ApiResponse> updateSection(SectionModel sectionModel);
        public Task<ApiResponse> deleteSection(int id);
        public Task<ApiResponse> getSectionDropDown();
    }
}
