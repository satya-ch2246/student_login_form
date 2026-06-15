using Student_Details.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Details.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        // GET: Student
        Student obj = new Student();
        public ActionResult Create()
        {
            TempData["Country"] = obj.CountryList;
            TempData.Keep();
            TempData["Courses"] = obj.CoursesList;
            TempData.Keep();
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student obj, FormCollection collection)
        {
            obj.Courses = collection["Courses"];
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = @"INSERT INTO Student_Details(FirstName, MiddleName, LastName, DateOfBirth, StudentId,Address, City, State, Country, ZIP, Email, Mobile, Courses) VALUES(@FirstName, @MiddleName, @LastName, @DateOfBirth, @StudentId,@Address, @City, @State, @Country, @ZIP, @Email, @Mobile, @Courses)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            if (obj.DateOfBirth == DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
            }
            cmd.Parameters.AddWithValue("@StudentId", obj.StudentId);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@Zip", obj.ZIP);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@Courses", obj.Courses);
            cmd.ExecuteNonQuery();
            con.Close();
            TempData["message"] = "Successfully Data registerd";
            return RedirectToAction("Create");

        }

    }
}