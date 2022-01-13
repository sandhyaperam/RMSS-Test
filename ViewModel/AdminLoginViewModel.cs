using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using InventoryApplication.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

using MySql.Data.MySqlClient;

namespace InventoryApplication.ViewModel
{
    public class AdminLoginViewModel
    {
        string connString = string.Empty;
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }




        public int LoginCheck(AdminLogin ad)
        {
          
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            MySqlConnection con = new MySqlConnection(connString);
            
            MySqlCommand com = new MySqlCommand("Sp_Login", con);
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", ad.UserName);
            com.Parameters.AddWithValue("@Password", ad.Password);
            MySqlParameter oblogin = new MySqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.MySqlDbType = MySqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}
