using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLO.Comman.ApiResponse
{
    public class ResponseMessage
    {
        public const string Error = "Some internal error occured";
        public const string UserExist = "Email already exist";
        public const string Success = "Record saved successfully";
        public const string UpdateSuccess = "Record Updated successfully";
        public const string RecordDeleted = "Record Deleted successfully";
        public const string RecordNotFound = "Record Not Found!";
        public const string PhoneExist = "Mobile number already exist";
        public const string InvalidXMLRSAkey = "Invalid XML RSA key";
        public const string InvalidKeySize = "Key size is not valid";
        public const string KeyIsNullOrEmpty = "Key is null or empty";
        public const string RSAKeyValue = "RSAKeyValue";
        public const string Modulus = "Modulus";
        public const string Exponent = "Exponent";
        public const string P = "P";
        public const string Q = "Q";
        public const string DP = "DP";
        public const string DQ = "DQ";
        public const string InverseQ = "InverseQ";
        public const string D = "D";
        public const string Expire = "Token has expired";
        public const string UserNotExist = "User does not exists";
        public const string InvalidPassword = "The password provided is incorret";
        public const string NoHarvestMove = "No harvest move found";
        public const string WasteAlreadyRemoved = "Waste already removed";
        public const string LabtestExist = "Labtest record already exists";
        public const string recSuccess = "Record inserted successfully";
        public const string LabTest = "Please provide LabTestResult id properly!";
        public const string File = "Please select pdf file!";
        public const string FileEncoded = "File encoded successfully";
        public const string NotFile = "Selected file is not in pdf format";
        public const string ProvidePdf = "Please provide pdf file name properly";
        public const string ProvideBase64 = "Please provide DocumentFileBase64 in correct format";
        public const string NoHarvestFound = "No harvest found";
        public const string WrongCredentials = "No user found! Check License Number.";
        public const string AdditiveAlreadyExist = "Additive already exists";
        public const string ValidEmail = "Please provide a valid mail!";
        public const string LogSuccess = "Login Success";
        public const string InvalidId = "Given Id is not found";
        public const string NotResultId = "Result Id not found";
        public const string UserSuccess = "User registered successfully!";
        public const string HarvestFinish = "Harvest finish record inserted successfully";
        public const string HarvestMove = "Harvest move record inserted successfully";
        public const string HarvestWaste = "Harvest waste record inserted successfully";
        public const string HarvestUnfinish = "Harvest unfinish record inserted successfully";
        public const string IsPassword = "Password should contain at least one lower case letter,one upper case letter,one numeric value,one special case characters & lenth should min 8 & max 16 characters. ";
        public const string InvalidModel = "Invalid model!";
        public const string PasswordError = "User id and password combination doesnot exists.";
        public const string RecordAddedSuccess = "Added successfully";
        public const string ImageFile = "Please select Image file!";
        public const string RecordsGet = "Records get successfully!";
        public const string DemoAllowed = "Demo Allowed successfully!";
        public const string NotDemoAllowed = "Demo Not Allowed successfully!";
        public const string FirstEmailConfirmDetails = "Email is not varified";
        public const string AcademicSessionUnlock = "Academic Session is Unlocked";
        public const string AcademicSessionlock = "Academic Session is locked";
        public const string ResetPassword = "Password has changed";
        public const string DepartmentExist = "Department is already exist";
        public const string SubjectCodeExist = "SubjectCode is already exist";
        public const string SubjectNameExist = "SubjectName is already exist";
        public const string SubjectCodeAndSubjectNameExist = "SubjectName and SubjectCode are already exist";
        public const string ClassNameExist = "ClassName is already exist";
        public const string ClassCodeExist = "ClassCode is already exist";
        public const string ClassNameAndCodeExist = "ClassName and ClassCode are already exist";
        public const string EmailExist = "Email is already exist";


    }
}
