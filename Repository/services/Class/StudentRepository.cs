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
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> createStudent(StudentModel studentModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var isEmailExist = await _context.Student.Where(x => (x.Email).ToLower() == studentModel.Email.ToLower()).FirstOrDefaultAsync();
                if (isEmailExist == null)
                {
                    var addStudent = new Student
                    {
                        AdmissionNumber = studentModel.AdmissionNumber,
                        FirstName = studentModel.FirstName,
                        MiddleName = studentModel.MiddleName,
                        LastName = studentModel.LastName,
                        ContactNumber = studentModel.ContactNumber,
                        GenderID = studentModel.GenderID,
                        BloodGroupID = studentModel.BloodGroupID,
                        Email = studentModel.Email,
                        DateOfBirth = studentModel.DateOfBirth,
                        Address = studentModel.Address,
                        ZipCode = studentModel.ZipCode,
                        StateID = studentModel.StateID,
                        CountryID = studentModel.CountryID,
                        City = studentModel.City,
                        ProfilePhoto = studentModel.ProfilePhoto,
                        StudentSkillID = studentModel.StudentSkillID,
                        ProfileSummary = studentModel.ProfileSummary,
                        FacebookLink = studentModel.FacebookLink,
                        LinkedInlink = studentModel.LinkedInlink,
                        ContactNumberCountryCode = studentModel.ContactNumberCountryCode,
                        UserID = Guid.NewGuid(),
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,
                        Block = false,
                        Alumni = false,
                        IsActive = true,
                        IsDeleted = false,
                        StudentExtraInfoInJson = studentModel.StudentExtraInfoInJson,
                    };

                    _context.Add(addStudent);
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.Success;
                    response.Status = (int)Number.One;
                    response.ResponseData = addStudent.StudentID;
                    var parent = new Parent
                    {
                        ParentsNumber = studentModel.ParentsNumber,
                        ParentEmail = studentModel.ParentEmail,
                        ParentContact = studentModel.ParentContact,
                        FatherName = studentModel.FatherName,
                        MotherName = studentModel.MotherName,
                        GuardianName = studentModel.GuardianName,
                        GuardianEmail = studentModel.GuardianEmail,
                        UserID = Guid.NewGuid(),
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,

                    };
                    _context.Add(parent);
                    await _context.SaveChangesAsync();
                    var addUser = new Users
                    {
                        HasExcess = true,
                        RememberMe = true,
                        Password = studentModel.Password,
                        FirstName = studentModel.FirstName,
                        LastName = studentModel.LastName,
                        UserName = studentModel.UserName,
                        Email = studentModel.Email,
                        PhoneNumber = studentModel.ContactNumber,
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,
                        RoleID = 1
                    };
                    _context.Add(addUser);
                    await _context.SaveChangesAsync();

                    var studentParent = new StudentParent
                    {
                        StudentID = addStudent.StudentID,
                        ParentID = parent.ParentID,
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,
                    };
                    _context.Add(studentParent);
                    await _context.SaveChangesAsync();

                    var studentClassSection = new StudentClassSection
                    {
                        AcademicSessionID = studentModel.AcademicSessionID,
                        ClassID = studentModel.ClassID,
                        SectionID = studentModel.SectionID,
                        StudentID = addStudent.StudentID,
                        CreatedBy = Guid.NewGuid(),
                        CreatedDate = DateTime.UtcNow,

                    };
                    _context.Add(studentClassSection);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.Message = ResponseMessage.EmailExist;
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse> deleteStudent(int id)
        {

            ApiResponse response = new ApiResponse();
            try
            {
                var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentID == id);
                var parentID = _context.StudentParent.Where(a => a.StudentID == id).FirstOrDefault().ParentID;
                var parent = await _context.Parent.FirstOrDefaultAsync(x => x.ParentID == parentID);
                //var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentID == id && x.IsDeleted == false);
                if (student != null)
                {
                    student.IsDeleted = true;
                    student.DeletedDate = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordDeleted;
                    response.Status = (int)Number.One;

                }
                if (parent != null)
                {
                    parent.IsDeleted = true;
                    parent.DeletedDate = DateTime.UtcNow;
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

        public async Task<ApiResponse> GetSectionByClassId(int classId)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                /*
                loop does not work in front-end in case of await _context.Section.FirstOrDefaultAsync(x => x.SectionID == classId)
                so we use
                */
                //response.ResponseData = await _context.Section.FirstOrDefaultAsync(x => x.SectionID == classId);
                response.ResponseData = await _context.Section.Where(x => x.SectionID == classId).ToListAsync();

                if (response.ResponseData != null)
                {
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;
                    response.Status = (int)Number.One;
                }
                else
                {
                    response.Message = ResponseMessage.RecordNotFound;
                    response.Status = (int)Number.Zero;
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ApiResponse> getStudentParentById(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await (from a in _context.Student.Where(x => x.StudentID == id && x.IsDeleted == false)
                                         join b in _context.StudentParent on a.StudentID equals b.StudentID
                                         join c in _context.Parent on b.ParentID equals c.ParentID
                                         join d in _context.StudentClassSection on a.StudentID equals d.StudentID
                                         select new StudentModel()
                                         {
                                             StudentID = a.StudentID,
                                             AdmissionNumber = a.AdmissionNumber,
                                             FirstName = a.FirstName,
                                             MiddleName = a.MiddleName,
                                             LastName = a.LastName,
                                             GenderID = a.GenderID,
                                             BloodGroupID = a.BloodGroupID,
                                             Email = a.Email,
                                             Address = a.Address,
                                             ZipCode = a.ZipCode,
                                             StateID = a.StateID,
                                             CountryID = a.CountryID,
                                             City = a.City,
                                             ProfilePhoto = a.ProfilePhoto,
                                             ProfileSummary = a.ProfileSummary,
                                             StudentSkillID = a.StudentSkillID,
                                             FacebookLink = a.FacebookLink,
                                             LinkedInlink = a.LinkedInlink,
                                             ContactNumberCountryCode = a.ContactNumberCountryCode,
                                             StudentExtraInfoInJson = a.StudentExtraInfoInJson,
                                             ContactNumber = a.ContactNumber,
                                             DateOfBirth = a.DateOfBirth,
                                             ParentsNumber = c.ParentsNumber,
                                             FatherName = c.FatherName,
                                             MotherName = c.MotherName,
                                             GuardianName = c.GuardianName,
                                             ParentContact = c.ParentContact,
                                             ParentEmail = c.ParentEmail,
                                             GuardianContact = c.GuardianContact,
                                             GuardianEmail = c.GuardianEmail,
                                             AcademicSessionID = d.AcademicSessionID,
                                             ClassID = d.ClassID,
                                             SectionID = d.SectionID,
                                         }).FirstOrDefaultAsync();
                if (response.ResponseData != null)
                {
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;
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

        public async Task<ApiResponse> getStudentDetailsByClassIdSectionIdAcademicId(int AcademicSessionID, int ClassID, int SectionID)
      {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await (from st in _context.Student
                                               join scs in _context.StudentClassSection on st.StudentID equals scs.StudentID into scsst
                                               from m in scsst.DefaultIfEmpty()
                                               join ass in _context.AcademicSession on m.AcademicSessionID equals ass.AcademicSessionID into ab
                                               from n in ab.DefaultIfEmpty()
                                               join c in _context.Class on m.ClassID equals c.ClassID into abc
                                               from o in abc.DefaultIfEmpty()
                                               join s in _context.Section on m.SectionID equals s.ClassID into abcd
                                               from q in abcd.DefaultIfEmpty()
                                               join sp in _context.StudentParent on st.StudentID equals sp.StudentID into abcde
                                               from t in abcde.DefaultIfEmpty()
                                               join p in _context.Parent on t.ParentID equals p.ParentID into abcdef
                                               from u in abcdef.DefaultIfEmpty()
                                               where
                                                   (AcademicSessionID == 0 || n.AcademicSessionID == AcademicSessionID)
                                                   && (ClassID == 0 || o.ClassID == ClassID)
                                                   && (SectionID == 0 || q.SectionID == SectionID)

                                               select new StudentDetailsByClassIdSectionIdAcademicIdModel
                                               {
                                                   StudentID = st.StudentID,
                                                   AdmissionNumber = st.AdmissionNumber,
                                                   FullName = st.FirstName + " " + st.MiddleName + " " + st.LastName,
                                                   GenderID = st.GenderID,
                                                   BloodGroupID = st.BloodGroupID,
                                                   Email = st.Email,
                                                   Address = st.Address,
                                                   ZipCode = st.ZipCode,
                                                   StateID = st.StateID,
                                                   CountryID = st.CountryID,
                                                   City = st.City,
                                                   ProfilePhoto = st.ProfilePhoto,
                                                   ProfileSummary = st.ProfileSummary,
                                                   StudentSkillID = st.StudentSkillID,
                                                   FacebookLink = st.FacebookLink,
                                                   LinkedInlink = st.LinkedInlink,
                                                   ContactNumberCountryCode = st.ContactNumberCountryCode,
                                                   StudentExtraInfoInJson = st.StudentExtraInfoInJson,
                                                   ContactNumber = st.ContactNumber,
                                                   DateOfBirth = st.DateOfBirth,
                                                   ParentsNumber = u.ParentsNumber,
                                                   FatherName = u.FatherName,
                                                   MotherName = u.MotherName,
                                                   GuardianName = u.GuardianName,
                                                   ParentContact = u.ParentContact,
                                                   ParentEmail = u.ParentEmail,
                                                   SectionName = q.SectionName,
                                                   SectionID = q.SectionID,
                                                   ClassName = o.ClassName,
                                                   ClassID = o.ClassID,
                                                   AcademicSessionName = n.AcademicSessionName,
                                                   AcademicSessionID = n.AcademicSessionID,
                                                   GuardianEmail = u.GuardianEmail,

                                               }).ToListAsync();
                if (response.ResponseData != null)
                {
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;
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

        public async Task<ApiResponse> getStudentList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = await _context.Student.Where(x => x.IsActive == true && x.IsDeleted == false).ToListAsync();
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
        public async Task<ApiResponse> getStudentParentList()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                response.ResponseData = (from a in _context.Student.Where(x => x.IsActive == true && x.IsDeleted == false)
                                         join b in _context.StudentParent on a.StudentID equals b.StudentID
                                         join c in _context.Parent on b.ParentID equals c.ParentID
                                         select new StudentModel()
                                         {
                                             AdmissionNumber = a.AdmissionNumber,
                                             FirstName = a.FirstName,
                                             ContactNumber = a.ContactNumber,
                                             DateOfBirth = a.DateOfBirth,
                                             ParentsNumber = c.ParentsNumber,
                                             FatherName = c.FatherName,
                                             MotherName = c.MotherName,
                                         }).ToList();
                if (response.ResponseData != null)
                {
                    response.Status = (int)Number.One;
                    response.StatusCode = ResponseCode.Ok;
                    response.Message = ResponseMessage.RecordsGet;
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

        public async Task<ApiResponse> updateStudent(StudentModel studentModel)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                if (studentModel.StudentID != 0)
                {
                    var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentID == studentModel.StudentID);
                    var parentID = _context.StudentParent.Where(a => a.StudentID == studentModel.StudentID).FirstOrDefault().ParentID;
                    var parent = await _context.Parent.FirstOrDefaultAsync(x => x.ParentID == parentID);
                    if (student != null)
                    {
                        student.StudentID = studentModel.StudentID;
                        student.AdmissionNumber = studentModel.AdmissionNumber;
                        student.FirstName = studentModel.FirstName;
                        student.MiddleName = studentModel.MiddleName;
                        student.LastName = studentModel.LastName;
                        student.ContactNumber = studentModel.ContactNumber;
                        student.GenderID = studentModel.GenderID;
                        student.BloodGroupID = studentModel.BloodGroupID;
                        student.Email = studentModel.Email;
                        student.DateOfBirth = studentModel.DateOfBirth;
                        student.Address = studentModel.Address;
                        student.ZipCode = studentModel.ZipCode;
                        student.StateID = studentModel.StateID;
                        student.CountryID = studentModel.CountryID;
                        student.City = studentModel.City;
                        student.ProfilePhoto = studentModel.ProfilePhoto;
                        student.StudentSkillID = studentModel.StudentSkillID;
                        student.ProfileSummary = studentModel.ProfileSummary;
                        student.FacebookLink = studentModel.FacebookLink;
                        student.LinkedInlink = studentModel.LinkedInlink;
                        student.ContactNumberCountryCode = studentModel.ContactNumberCountryCode;
                        student.UserID = Guid.NewGuid();
                        student.ModifyBy = Guid.NewGuid();
                        student.ModifiedDate = DateTime.UtcNow;
                        student.Block = false;
                        student.Alumni = false;
                        student.StudentExtraInfoInJson = studentModel.StudentExtraInfoInJson;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                    }
                    else
                    {
                        response.Message = ResponseMessage.RecordNotFound;
                        response.Status = (int)Number.Zero;
                    }
                    if (parent != null)
                    {
                        parent.ParentsNumber = studentModel.ParentsNumber;
                        parent.ParentEmail = studentModel.ParentEmail;
                        parent.ParentContact = studentModel.ParentContact;
                        parent.FatherName = studentModel.FatherName;
                        parent.MotherName = studentModel.MotherName;
                        parent.GuardianName = studentModel.GuardianName;
                        parent.GuardianEmail = studentModel.GuardianEmail;
                        parent.UserID = Guid.NewGuid();
                        parent.ModifyBy = Guid.NewGuid();
                        parent.ModifiedDate = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        response.Status = (int)Number.One;
                        response.StatusCode = ResponseCode.Ok;
                        response.Message = ResponseMessage.UpdateSuccess;
                    }
                    else
                    {
                        response.Message = ResponseMessage.RecordNotFound;
                        response.Status = (int)Number.Zero;
                    }
                }
                else
                {
                    response.Message = ResponseMessage.RecordNotFound;
                    response.Status = ResponseCode.NotFound;
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
