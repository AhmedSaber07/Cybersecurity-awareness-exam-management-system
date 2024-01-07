using ExamManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagementApp.Dtos;

namespace ExamManagementApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<FinalResult> FinalResults { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ExamManagementApp.Dtos.ChangeAdminPasswordDto> ChangeAdminPasswordDto { get; set; }
        //public DbSet<Choice> Choices { get; set; }
        //public DbSet<Registeration> Registerations { get; set; }
    }
}
