using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeProject.DAL
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("name=EmployeeContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employee");

        }
        public DbSet<Employee> Employees { get; set; }
    }
}