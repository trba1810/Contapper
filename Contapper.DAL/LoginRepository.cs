using Contapper.DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contapper.DAL
{
    public class LoginRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public bool AuthenticatUserBy(string username, string password)
        {
            var user = new User();
            try
            {
                var sql = "SELECT * FROM User WHERE Username='" +username + "' and Password = '" + password + "'";
                
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    var command = new SQLiteCommand(sql, connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //var user  = new User
                            //{
                            //    Username = reader["Username"].ToString(),
                            //    Password = reader["Password"].ToString(),
                            //};
                            user.Username = reader["Username"].ToString();
                            user.Password = reader["Password"].ToString();
                        }
                        if (string.IsNullOrEmpty(user.Username) && (string.IsNullOrEmpty(user.Password)))
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //public  List<User> GetAllUsers()
        //{
        //    var users = new List<User>();

        //    var sql = "SELECT * FROM User";

        //    using (var connection = new SQLiteConnection(_connectionString))
        //    {
        //        try
        //        {
        //            var command = new SQLiteCommand(sql, connection);
        //            connection.Open();
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var newUser = new User
        //                    {
        //                        Username = reader["Username"].ToString(),
        //                        Password = reader["Password"].ToString(),
        //                    };
        //                    users.Add(newUser);
        //                }
        //            }
        //            return users;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }
        //    }
        //}
    }
}
