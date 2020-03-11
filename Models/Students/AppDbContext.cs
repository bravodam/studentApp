using Code360_Management.Models.Batchs;
using Code360_Management.Models.Courses;
using Code360_Management.Models.Employment;
using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Payments;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Students_In_Batch;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Students
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Programme> Programs { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<StudentInBatch> student_in_batch { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<StudentGuarantor> studentGuarantors { get; set; }
        public DbSet<ProgramCourse> programCourses { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PaymentHistory> payHistory { get; set; }
        public DbSet<Company> compnay { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<EmploymentHistory> employmentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // A One-to-Many Relationship between A STUDENT and PROJECT
            modelBuilder.Entity<Project>()
                        .HasOne(p => p.student)
                        .WithMany(s => s.listOfProjects);

            // A One-to-Many Relationship between BATCH and PROGRAM
            modelBuilder.Entity<Batch>()
                        .HasOne(p => p.programme)
                        .WithMany(b => b.BatchList);

            // A Many-to-Many Relationship between a PROGRAM and COURSE
            modelBuilder.Entity<ProgramCourse>()
                        .HasKey(k => new { k.CourseId, k.ProgramID });

            modelBuilder.Entity<ProgramCourse>()
                        .HasOne(pc => pc.programme)
                        .WithMany(pc => pc.ListProgramCourses)
                        .HasForeignKey(pc => pc.ProgramID);
            modelBuilder.Entity<ProgramCourse>()
                        .HasOne(pc => pc.course)
                        .WithMany(pc => pc.ListProgramCourses)
                        .HasForeignKey(pc => pc.CourseId);

            // A Many-to-Many Relationship between STUDENT and BATCH
            modelBuilder.Entity<StudentInBatch>()
                        .HasKey(k => new { k.Batch_Id, k.Student_Id });

            modelBuilder.Entity<StudentInBatch>()
                        .HasOne(s => s.student)
                        .WithMany(s => s.ListOfstudentInBatches)
                        .HasForeignKey(s => s.Student_Id);
            modelBuilder.Entity<StudentInBatch>()
                        .HasOne(b => b.Batch)
                        .WithMany(b => b.ListOfstudentInBatch)
                        .HasForeignKey(b => b.Batch_Id);

            // A Many-to-Many Relationship between STUDENT and GUARANTOR
            modelBuilder.Entity<StudentGuarantor>()
                        .HasKey(k => new { k.GuarantorId, k.StudentId });

            modelBuilder.Entity<StudentGuarantor>()
                        .HasOne(s => s.student)
                        .WithMany(s => s.ListStudentGuarantor)
                        .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<StudentGuarantor>()
                        .HasOne(g => g.guarantor)
                        .WithMany(g => g.ListStudentGuarantor)
                        .HasForeignKey(g => g.GuarantorId);

            // A Many-to-Many Relationship between STUDENT and COURSE
            modelBuilder.Entity<StudentCourse>()
                        .HasKey(k => new { k.CourseId, k.StudentId });

            modelBuilder.Entity<StudentCourse>()
                        .HasOne(s => s.student)
                        .WithMany(s => s.ListstudentCourses)
                        .HasForeignKey(s => s.StudentId);
            modelBuilder.Entity<StudentCourse>()
                        .HasOne(g => g.course)
                        .WithMany(g => g.ListstudentCourses)
                        .HasForeignKey(g => g.CourseId);


            // A One-to-Many Relationship between STUDENT and PAYMENT
            modelBuilder.Entity<Payment>()
                        .HasOne(p => p.student)
                        .WithMany(s => s.ListOfPayment);

            // A One-to-Many Relationship between PAYMENT and PAYMENTHISTORY
            modelBuilder.Entity<PaymentHistory>()
                        .HasOne(p => p.payment)
                        .WithMany(h => h.ListOfPayment);

            // A One-to-Many Relationship between EMPLOYMENTHISTORY and SALARY
            modelBuilder.Entity<Salary>()
                        .HasOne(e => e.employmentHistory)
                        .WithMany(s => s.ListOfSalaries);

            // A Many-to-Many Relationship between STUDENT and COMPANY
            modelBuilder.Entity<EmploymentHistory>()
                        .HasKey(k => new { k.StudentId, k.CompID });

            modelBuilder.Entity<EmploymentHistory>()
                        .HasOne(s => s.student)
                        .WithMany(s => s.ListOfEmpHistory)
                        .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<EmploymentHistory>()
                        .HasOne(c => c.company)
                        .WithMany(c => c.listOfEmpHistory)
                        .HasForeignKey(c => c.CompID);
                        

            //A One-to-One Relationship between A STUDENT and a BATCH
            //modelBuilder.Entity<Student>().HasOne(s => s.BatchPpt).WithOne(b => b.student).HasForeignKey<Batch>(s => s.studentForeignKey);

            //A Many-to-Many Relationship between PROGRAM and COURSE


 
        }
    }
}
