using crudEMS.Models;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace crudEMS.DAL
{
    public class Employee_DAL
    {
        SqlConnection? _connection = null;
        SqlCommand? _command = null;
        public static IConfiguration? Configuration { get; set; }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[get_Employees]";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpID = Convert.ToInt32(dr["EmpID"]);
                    employee.FirstName = dr["FirstName"].ToString();
                    employee.LastName = dr["LastName"].ToString();
                    employee.DOB = Convert.ToDateTime(dr["DOB"]).Date;
                    employee.Email = dr["Email"].ToString();
                    employee.Mobile = Convert.ToDecimal(dr["Mobile"]);
                    employee.Address = dr["Address"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.Salary = Convert.ToDecimal(dr["Salary"]);
                    employeeList.Add(employee);
                }
                _connection.Close();
            }
            return employeeList;
        }

        public bool Insert(Employee model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[insert_Employee]";
                _command.Parameters.AddWithValue("@LastName", model.LastName);
                _command.Parameters.AddWithValue("@FirstName", model.FirstName);
                _command.Parameters.AddWithValue("@DOB", model.DOB);
                _command.Parameters.AddWithValue("@Email", model.Email);
                _command.Parameters.AddWithValue("@Mobile", model.Mobile);
                _command.Parameters.AddWithValue("@Address", model.Address);
                _command.Parameters.AddWithValue("@Department", model.Department);
                _command.Parameters.AddWithValue("@Designation", model.Designation);
                _command.Parameters.AddWithValue("@Salary", model.Salary);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();

            }
            return id > 0 ? true : false;
        }

        public Employee GetById(int id)
        {
            Employee employee = new Employee();

            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[get_EmployeesById]";
                _command.Parameters.AddWithValue("@EmpID", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();

                while (dr.Read())
                {

                    employee.EmpID = Convert.ToInt32(dr["EmpID"]);
                    employee.FirstName = dr["FirstName"].ToString();
                    employee.LastName = dr["LastName"].ToString();
                    employee.DOB = Convert.ToDateTime(dr["DOB"]).Date;
                    employee.Email = dr["Email"].ToString();
                    employee.Mobile = Convert.ToDecimal(dr["Mobile"]);
                    employee.Department = dr["Department"].ToString();
                    employee.Address = dr["Address"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.Salary = Convert.ToDecimal(dr["Salary"]);

                }
                _connection.Close();
            }
            return employee;
        }

        public bool Update(Employee model)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[update_Employee]";
                _command.Parameters.AddWithValue("@EmpID", model.EmpID);
                _command.Parameters.AddWithValue("@LastName", model.LastName);
                _command.Parameters.AddWithValue("@FirstName", model.FirstName);
                _command.Parameters.AddWithValue("@DOB", model.DOB);
                _command.Parameters.AddWithValue("@Email", model.Email);
                _command.Parameters.AddWithValue("@Mobile", model.Mobile);
                _command.Parameters.AddWithValue("@Address", model.Address);
                _command.Parameters.AddWithValue("@Department", model.Department);
                _command.Parameters.AddWithValue("@Designation", model.Designation);
                _command.Parameters.AddWithValue("@Salary", model.Salary);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();

            }
            return id > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            int deletedRowCount = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[DBO].[delete_Employee]";
                _command.Parameters.AddWithValue("@EmpID", id);
                _connection.Open();
                deletedRowCount = _command.ExecuteNonQuery();
                _connection.Close();

            }
            return deletedRowCount > 0 ? true : false;
        }

    }
}
