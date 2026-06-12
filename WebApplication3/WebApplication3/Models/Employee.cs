using Microsoft.Data.SqlClient;
using System.Data;
namespace WebApplication3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public List<Employee> GetAllEmployes()
        {
            var employeeList=new List<Employee>();
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;database=netcore;trustservercertificate=true;integrated security=yes");
            string query = "select * from Employee";
            SqlCommand cmd=new SqlCommand(query, con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();   
            da.Fill(dt);    
            foreach(DataRow dr in dt.Rows)
            {
                employeeList.Add(
                    new Employee()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        Address = Convert.ToString(dr["Address"])
                    });
             
            }
            return employeeList;
        }
        public void AddEmployee(Employee obj)
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;database=netcore;trustservercertificate=true;integrated security=yes");
            con.Open();
            string query = "insert into employee values(@Id,@Name,@Age,@Address)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id",obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EditEmployee(Employee obj)
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;database=netcore;trustservercertificate=true;integrated security=yes");
            con.Open();
            string query = "update employee set name=@name,age=@age,address=@address where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;database=netcore;trustservercertificate=true;integrated security=yes");
            con.Open();
            string query = "delete from employee where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
