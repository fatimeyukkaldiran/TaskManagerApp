using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerApp.Models
{
    public class ModelEmployeeTask
    {
        [Key]
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public ModelEmployeeRegister Employee { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? Start_Date { get; set; }

        [Display(Name = "End Date")]
        public DateTime? End_Date { get; set; }

        [Display(Name = "Task Details")]
        public string TaskDetails { get; set; }
        public bool? Status { get; set; }

    }
}
