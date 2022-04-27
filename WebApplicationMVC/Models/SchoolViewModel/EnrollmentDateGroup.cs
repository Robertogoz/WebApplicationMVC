using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models.SchoolViewModel
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.DateTime)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
