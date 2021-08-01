using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerApp.Models
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> option) : base(option)
        {

        }

        public DbSet<ModelAdminLogin> AdminDetails { get; set; }
        public DbSet<ModelEmployeeRegister> EmployeeRegisters { get; set; }
        public DbSet<ModelEmployeeTask> EmployeeTasks { get; set; }

    }
}
