using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF.Models/*Metadata*/
{
    public class CourseMetadata
    {
        //public int CourseId { get; set; }
        [Required(ErrorMessage = "*Course Name is required")]
        [StringLength(50, ErrorMessage ="*Max 50 characters")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = null!;
        [Required(ErrorMessage = "*Course Description is required")]
        [Display(Name = "Course Description")]
        [DataType(DataType.MultilineText)]  
        public string CourseDescription { get; set; } = null!;
        [Required(ErrorMessage = "*Credit Hours is required")]
        [Display(Name = "Credit Hours")]
        [Range(0, 10)]
        public byte CreditHours { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "*Max 250 characters")]
        public string? Curriculum { get; set; }
        [StringLength(500, ErrorMessage = "*Max 500 characters")]
        public string? Notes { get; set; }
        [Required(ErrorMessage = "*Is Active is required")]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }

    public class EnrollmentMetadata
    {
        //public int EnrollmentId { get; set; }
        //public int StudentId { get; set; }
        //public int ScheduledClassId { get; set; }
        [Required(ErrorMessage = "*Enrollment Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        //public virtual ScheduledClass ScheduledClass { get; set; } = null!;
        //public virtual Student Student { get; set; } = null!;
    }

    public class ScheduledClassMetadata
    {
        //public int ScheduledClassId { get; set; }
        //public int CourseId { get; set; }
        [Required(ErrorMessage = "*Start Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*End Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*Instructor Name is required")]
        [StringLength(40, ErrorMessage = "*Max 40 characters")]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; } = null!;

        [Required(ErrorMessage = "*Location is required")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        
        public string Location { get; set; } = null!;
        //public int Scsid { get; set; }
    }

    public class ScheduledClassStatusMetadata
    {
        [Required(ErrorMessage = "*Class Status is required")]
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        [Display(Name = "Class Status")]
        public string Scsname { get; set; } = null!;
    }

    public class StudentMetadata
    {
        //public int StudentId { get; set; }

        [Required(ErrorMessage = "*First Name is required")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "*Last Name is required")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        
        [StringLength(15, ErrorMessage = "*Max 15 characters")]        
        public string? Major { get; set; }

        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        public string? Address { get; set; }

        [StringLength(25, ErrorMessage = "*Max 25 characters")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "*Max 2 characters")]
        public string? State { get; set; }

        [StringLength(10, ErrorMessage = "*Max 10 characters")]
        public string? ZipCode { get; set; }

        [StringLength(13, ErrorMessage = "*Max 13 characters")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "*Email is required")]
        [StringLength(60, ErrorMessage = "*Max 60 characters")]
        
        public string Email { get; set; } = null!;

        [StringLength(100, ErrorMessage = "*Max 100 characters")]
        public string? PhotoUrl { get; set; }
        //public int Ssid { get; set; }
    }

    public class StudentStatusMetadata
    {
        //public int Ssid { get; set; }

        [Required(ErrorMessage = "*Status is required")]
        [StringLength(30, ErrorMessage = "*Max 30 characters")]
        [Display(Name = "Status")]
        public string Ssname { get; set; } = null!;

        [StringLength(250, ErrorMessage = "*Max 250 characters")]
        [Display(Name = "Description")]
        public string? Ssdescription { get; set; }
    }
}
