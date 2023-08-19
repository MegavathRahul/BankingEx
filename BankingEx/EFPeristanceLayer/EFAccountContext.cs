using System.Collections.Generic;
using BankingEx.EFModels;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;



namespace BankingEx.EFPersistenceLayer
{
    public class EFAccountContext
    {
        public static bool Create(Account account)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";

            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>().UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                db.Accounts.Add(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static List<Account> GetAccounts()
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";

            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>().UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                List<Account> accounts = db.Accounts.ToList();

                return accounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Account GetAccountById(int id)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";

            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>().UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                Account account = db.Accounts.Find(id);
                db.Entry(account).Reference(b => b.Customer).Load();
                return account;
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
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>().UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                Account dbAccount = db.Accounts.Find(id);
                db.Accounts.Remove(dbAccount);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public static Account UpdateAccount(Account account)
        {
            string connectionString = "Server =(localdb)\\RahulAudree;Database=AudreeBank1;User Id=Rahul;Password=Rahul12;encrypt=false";
            try
            {
                DbContextOptionsBuilder<AudreeBank1Context> optionsBuilder = new DbContextOptionsBuilder<AudreeBank1Context>().UseSqlServer(connectionString);
                AudreeBank1Context db = new AudreeBank1Context(optionsBuilder.Options);
                db.Accounts.Update(account);
                db.SaveChanges();
                return account;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}