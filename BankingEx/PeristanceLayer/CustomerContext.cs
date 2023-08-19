using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingEx.Models;
using Microsoft.Data.SqlClient;


namespace BankingEx.Peristance
{
    public class CustomerContext
    {
        public static bool Create(Customer customer)
        {
            SqlConnection connection = new SqlConnection("Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");


            try
            {
                string dbDateFormat = customer.DoB.ToString("yyyy-MM-dd");
                string insertCommand = $"INSERT INTO dbo.Customer(name,Dob,PanNumber,City)" +
                                     $"VALUES('{customer.Name}',{dbDateFormat},'{customer.PAN}'" +
                                     $",'{customer.City}')";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                connection.Open();
                int resultCount = command.ExecuteNonQuery();
                connection.Close();
                if (resultCount > 0)
                {
                    return true;

                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }



        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false");


            try
            {
                string selectCommand = "SELECT * FROM dbo.Customer";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                connection.Open();
                SqlDataReader resultreader = command.ExecuteReader();
                while(resultreader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = int.Parse(resultreader["Id"].ToString());
                    customer.Name = resultreader["Name"].ToString();
                    customer.DoB = DateTime.Parse(resultreader["Dob"].ToString());
                    customer.PAN = resultreader["PanNumber"].ToString();
                    customer.City =resultreader["City"].ToString();
                    customers.Add(customer);
                }
                connection.Close();
                return customers;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }



        }
    }
    }


