using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using System.IO;
using InventoryApplication.Areas.Admin.Models;

namespace InventoryApplication.Areas.Admin.ViewModel
{
    public class CountryViewModel
    {
        string connString = string.Empty;
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }
        public bool AddCountry(CountryModel objModel)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            SqlCommand com = new SqlCommand("Insert_CountryMaster", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", objModel.Name);
         

            //      result = Convert.ToString(cmd.ExecuteScalar());

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        public List<CountryModel> GetAllCountry()
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            List<CountryModel> EmpList = new List<CountryModel>();


            SqlCommand com = new SqlCommand("sp_GetAllCountryMaster", connection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            connection.Open();
            da.Fill(dt);
            connection.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new CountryModel
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"])
                       
                    }
                    );
            }

            return EmpList;
        }

        public bool UpdateCountry(CountryModel obj)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);


            SqlCommand com = new SqlCommand("sp_UpdateCountryMaster", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", obj.Id);
            com.Parameters.AddWithValue("@Name", obj.Name);
           

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteCountry(int Id)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            SqlCommand com = new SqlCommand("sp_DeleteCountryMaster", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", Id);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
