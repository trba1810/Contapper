using Contapper.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Globalization;

namespace Contapper.DAL
{
    public class CompaniesDal
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;



        public List<Company> GetAllCompanies()
        {
            var companies = new List<Company>();

            var sql = "SELECT * FROM Company";

            using (var connection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var newCompany = new Company
                            {

                                Id = reader["Id"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                City = reader["City"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Status = GetStatusFromDB(reader["Status"]),
                                FirstEntryDate = reader["FirstEntryDate"].ToString(),
                                Details = reader["Details"].ToString()

                            };
                            companies.Add(newCompany);
                        }                             
                    }
                    return companies;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public Status GetStatusFromDB(object status)
        {
            var s = status.ToString();
            if (s == Status.Interested.ToString())
            {
                return Status.Interested;
            }
            
            if (s == Status.Indeterminate.ToString())
            {
                return Status.Indeterminate;
            }
            if (s== Status.NotInterested.ToString())
            {
                return Status.NotInterested;
            }
            if (s == Status.Compensation.ToString())
            {
                return Status.Compensation;
            }
            if (s == Status.Block.ToString())                   
            {
                return Status.Block;
            }
            return Status.NotInterested;
        }

        public bool InsertNewCompany(Company company)
        {
            var sql = "INSERT INTO Company(Id,CompanyName,City,Address,PhoneNumber,Status,FirstEntryDate,Details) values('" + company.Id + "','" + company.CompanyName + "','" + company.City + "','" + company.Address + "','" + company.PhoneNumber + "','" + company.Status + "','" + company.FirstEntryDate + "','" + company.Details + "')";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    using (command.ExecuteReader())
                    {
                        command.Parameters.Add(new SQLiteParameter("@Id", DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@CompanyName",DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@City",DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@Address", DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@PhoneNumber", DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@Status", DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@FirstEntryDate", DbType.String));
                        command.Parameters.Add(new SQLiteParameter("@Details", DbType.String));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateCompany(Company company) //TODO Finish this up
        {
            var sql = "UPDATE Company SET CompanyName = '" + company.CompanyName + "', City = '" + company.City + "', Address = '" + company.Address + "', Date = '" + company.FirstEntryDate + "'WHERE ID = '" + company.Id + "'";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    using (command.ExecuteReader())
                    {
                        command.Parameters.AddWithValue("@CompanyName", DbType.String); // bez ID
                        command.Parameters.AddWithValue("@City", DbType.String);
                        command.Parameters.AddWithValue("@Address", DbType.String);
                        command.Parameters.AddWithValue("@FirstEntryDate", DbType.String);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteCompany(string id)
        {
            var sql = "DELETE FROM Company WHERE Id = " + "' +" + id + "'";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }      
    }
}
