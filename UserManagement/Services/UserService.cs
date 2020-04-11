using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private MySqlService MySqlDatabase { get; set; }

        public UserService(MySqlService mySqldatabase)
        {
            this.MySqlDatabase = mySqldatabase;
        }
        public User getUserDetails(int Id)
        {
            var user = new User();
            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * from Users Where Id = @Id";
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.ExecuteNonQuery();
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    user = new User()
                    {
                        Id = reader.GetFieldValue<Int32>(0),
                        Name = reader.GetFieldValue<string>(1),
                        Age = reader.GetFieldValue<Int32>(2),
                        Email = reader.GetFieldValue<string>(3)
                    };
                }
            return user;
        }
    }
}
