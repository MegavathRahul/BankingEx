using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingEx.EFModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace BankingEx.EFPeristanceLayer
{
    public class EFCustomerContext
    {
        public static bool Create(Customer customer)
        {
            string connectionString ="Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";


            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>();
                optionsBuilder.UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                db.Customers.Add(customer);
                db.SaveChanges();
                return true;

            }
            catch (System.Exception ex)
            {
                throw;
            }
            finally
            {
                
            }
        }

        public static Customer GetCustomerById(int id)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";


            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>();
                optionsBuilder.UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                Customer customer = db.Customers.Find(id);
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static List<Customer> GetCustomers()
        {
            string connectionString ="Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";
            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>();
                optionsBuilder.UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                List<Customer> customers = db.Customers.ToList();
                return customers;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                
            }



        }
        public static bool UpdateCustomer(Customer customer)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";


            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>();
                optionsBuilder.UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                db.Customers.Update(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool Delete(int id)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";

            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>();
                optionsBuilder.UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);

                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
    }


