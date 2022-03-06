using DataAcessLayer.Entities;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.DbContext
{
    public class AppDbContext : IdentityDbContext
    //public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>,
    //IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organization { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AcademicSession> AcademicSession { get; set; }
        public DbSet<AcademicSessionStatus> AcademicSessionStatus { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Classess> Class { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<StudentParent> StudentParent { get; set; }
        public DbSet<StudentClassSection> StudentClassSection { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<SubjectEnrollmentStatus> SubjectEnrollmentStatus { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollment { get; set; }
        public DbSet<EnrollmentStatus> EnrollmentStatus { get; set; }

    }
}
