using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Services
{
    public class MySqlService : IDisposable
    {
        public MySqlConnection Connection;

        public MySqlService(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
            //this.SeedData();
        }

        public void SeedData()
        {
            FileInfo file = new FileInfo("script.sql");

            string script = file.OpenText().ReadToEnd();
            var cmd = this.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();

        }

        public void Dispose()
        {
            Connection.Close();
        }

    }
}
