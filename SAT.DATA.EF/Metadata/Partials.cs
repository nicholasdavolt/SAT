using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;



namespace SAT.DATA.EF.Models/*Metadata*/
{
    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }

    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {
                
    }

    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {

        
        public string? ClassInfo
        {
            get
            {
                if (Course == null)
                {
                    return null;
                }
                else
                {
                    return string.Format($"{Course.CourseName} - {StartDate:d}");
                }
            }
        }

    }

    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus
    {
      

    }

    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    }

    [ModelMetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus
    {

    }
}
