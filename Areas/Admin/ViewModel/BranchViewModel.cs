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
    public class BranchViewModel
    {
        int i = 0;
        string connString = string.Empty;
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }
        public bool AddEmployee(BranchModel objModel)
        {
            try
            { 
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            SqlCommand com = new SqlCommand("Insert_BranchMaster", connection);
                com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", objModel.Name);
            com.Parameters.AddWithValue("@Address", objModel.Address);
            com.Parameters.AddWithValue("@Mobile", objModel.Mobile);
            com.Parameters.AddWithValue("@Email", objModel.Email);


      //      result = Convert.ToString(cmd.ExecuteScalar());

            connection.Open();
            i= com.ExecuteNonQuery();
            connection.Close();
           
            }
            catch(Exception ex)
            {
                ex.ToString();
               
            }
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }
        public List<BranchModel> GetAllEmployees()
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            List<BranchModel> EmpList = new List<BranchModel>();


            SqlCommand com = new SqlCommand("sp_GetAllBranchMaster", connection);
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

                    new BranchModel
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"])
                    }
                    );
            }

            return EmpList;
        }

        public bool UpdateEmployee(BranchModel obj)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);


            SqlCommand com = new SqlCommand("sp_UpdateBranchMaster", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", obj.Id);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Mobile", obj.Mobile);
            com.Parameters.AddWithValue("@Emailid", obj.Email);


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
        public bool DeleteEmployee(int Id)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            SqlConnection connection = new SqlConnection(connString);

            SqlCommand com = new SqlCommand("sp_DeleteBranchMaster", connection);

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

