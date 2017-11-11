using Contapper.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

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
                            var company = new Company
                            {

                                Id = (reader["Id"]).ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                City = reader["City"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Status = GetStatusFromDB(reader["Status"]),
                                Date = DateTime.Parse(reader["Date"]?.ToString()),
                                Details = reader["Details"].ToString()

                            };
                            companies.Add(company);
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
            var sql = "INSERT INTO Company(Id,CompanyName,City,Address,PhoneNumber,Status,Date,Details) values('" +company.Id + "','" + company.CompanyName + "','" + company.City + "','" + company.Address + "','" + company.PhoneNumber + "','" + company.Status + "','" + company.Date.ToShortDateString() + "','" + company.Details + "')";

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
                        command.Parameters.Add(new SQLiteParameter("@Date", DbType.String));
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

        public bool UpdateCompany(Company company)
        {
            var sql = "UPDATE Company SET CompanyName = '" + company.CompanyName + "', City = '" + company.City + "', Address = '" + company.Address + "', Date = '" + company.Date.ToShortDateString() + "'WHERE ID = '" + company.Id + "'";

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
                        command.Parameters.AddWithValue("@Date", DbType.String);
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

        public bool InsertNewLocation(string id ,string locationLink)
        {
            var sql = "INSERT INTO CompanyLocation (CompanyId, Location) values ('" + id + "','" + locationLink + "')";

            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    using (command.ExecuteReader())
                    {
                        command.Parameters.Add(new SQLiteParameter("@CompanyId", DbType.Int32));
                        command.Parameters.Add(new SQLiteParameter("@Location", DbType.String));                       
                    }                    
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
