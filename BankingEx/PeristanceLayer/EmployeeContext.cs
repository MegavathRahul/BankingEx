using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingEx.Models;
using Microsoft.Data.SqlClient;

namespace BankingEx.PeristanceLayer
{
    public class EmployeeContext
    {
        public static bool Create(Employee employee)
        {
            SqlConnection conn= new SqlConnection("Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");
            try
            {
                //string dbDataFormat = employee..ToString("yyyy-MM-dd");

                string insert = $"INSERT INTO dbo.Employee(Name,Username,password) " + $"VALUES('{employee.Name}','{employee.Username}','{employee.password}')";

                SqlCommand cmd = new SqlCommand(insert, conn);
                conn.Open();
                int resultcount = cmd.ExecuteNonQuery();
                conn.Close();
                if (resultcount > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static List<Employee> GetEmployee()
        {
            List<Employee> custm = new List<Employee>();
            SqlConnection conn = new SqlConnection("Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");
            try
            {
                string input = "SELECT * FROM dbo.Employee";
                SqlCommand cmd = new SqlCommand(input, conn);
                conn.Open();
                SqlDataReader resultReader = cmd.ExecuteReader();
                while (resultReader.Read())
                {

                    Employee cust2 = new Employee();
                    cust2.Id = int.Parse(resultReader["Id"].ToString());
                    cust2.Name = resultReader["Name"].ToString();
                    cust2.Username = resultReader["Username"].ToString();
                    cust2.password = resultReader["password"].ToString();
                    custm.Add(cust2);
                }
                conn.Close();
                return custm;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static Employee Login(string Username, string password)
        {
            //List<Employee> custm = new List<Employee>();
            SqlConnection conn = new SqlConnection("Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");
            Employee cust3 = null;
            try
            {

                string input = $"SELECT * FROM dbo.Employee WHERE Username='{Username}' AND password='{password}'";
                SqlCommand cmd = new SqlCommand(input, conn);
                conn.Open();
                SqlDataReader resultReader = cmd.ExecuteReader();
                while (resultReader.Read())
                {

                    cust3 = new Employee();
                    cust3.Id = int.Parse(resultReader["Id"].ToString());
                    cust3.Name = resultReader["Name"].ToString();
                    cust3.Username = resultReader["Username"].ToString();
                    cust3.password = resultReader["password"].ToString();
                    //custm.Add(cust2);
                }
                conn.Close();
                return cust3;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static Employee GetEmployeeById(int id)
        {
            SqlConnection conn = new SqlConnection("Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");
            Employee cust3 = null;
            try
            {

                string input = $"SELECT * FROM dbo.Employee" +
                               $" WHERE id={id}";
                SqlCommand cmd = new SqlCommand(input, conn);
                conn.Open();
                SqlDataReader resultReader = cmd.ExecuteReader();
                while (resultReader.Read())
                {

                    cust3 = new Employee();
                    cust3.Id = int.Parse(resultReader["id"].ToString());
                    cust3.Name = resultReader["Name"].ToString();
                    cust3.Username = resultReader["Username"].ToString();
                    cust3.password = resultReader["password"].ToString();
                    //custm.Add(cust2);
                }
                conn.Close();
                return cust3;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }


    }
}