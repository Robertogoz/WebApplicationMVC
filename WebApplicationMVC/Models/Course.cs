﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMVC.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department? Department { get; set; }
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
