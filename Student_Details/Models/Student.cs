using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Details.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int StudentId { get; set; }  
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZIP { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Courses { get; set; }

        public List<string> CoursesList
        {
            get
            {
                var value = new List<string>()
         {
             "DotNet",
             "Java",
             "Python",
             "ReactJS"
         };
                return value;
            }
        }
        public List<string> CountryList
        {
            get
            {
                var value = new List<string>()
         {
             "India",
             "Russia",
             "USA",
             "Japan",
             "China",
             "Germany",
             "France",
             "Italy",
             "Spain",
             "Australia"
         };
                return value;
            }
        }

    }
}