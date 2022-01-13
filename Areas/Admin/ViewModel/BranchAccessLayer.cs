using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using InventoryApplication.Areas.Admin.Models;

namespace InventoryApplication.Areas.Admin.ViewModel
{

   
    public class BranchAccessLayer
    {
        string connString = string.Empty;
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }

        public IEnumerable<BranchModel> GetAllCustomers()
        {
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;



            List<BranchModel> lstCustomer = new List<BranchModel>();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    BranchModel temobj = new BranchModel();

                    temobj.Id = Convert.ToInt32(sdr["Id"].ToString());
                    //temobj.ClaimDate = Convert.ToDateTime(sdr["ClaimDate"].ToString());
                    temobj.Name = Convert.ToString(sdr["Name"]);


                    temobj.Address = Convert.ToString(sdr["Address"]);
                    temobj.Mobile = Convert.ToString(sdr["Mobile"]);
                    temobj.Email = Convert.ToString(sdr["Email"]);

                    lstCustomer.Add(temobj);
                }
                con.Close();
            }
            return lstCustomer;
        }

        //To Add new Customer record      
        public void AddCustomer(BranchModel Customer)
        {
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;


            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Insert_BranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Address", Customer.Address);
                cmd.Parameters.AddWithValue("@Mobile", Customer.Mobile);
                cmd.Parameters.AddWithValue("@Email", Customer.Email);

                con.Open();
                string result = Convert.ToString(cmd.ExecuteScalar());
                con.Close();

            }
        }

        //To Update the records of a particluar Customer    
        public void UpdateCustomer(BranchModel Customer)
        {
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", Customer.Id);
                cmd.Parameters.AddWithValue("@Name", Customer.Name);
                cmd.Parameters.AddWithValue("@Address", Customer.Address);
                cmd.Parameters.AddWithValue("@Mobile", Customer.Mobile);
                cmd.Parameters.AddWithValue("@Emailid", Customer.Email);
               

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular Customer    
        public BranchModel GetCustomerData(int? id)
        {
            BranchModel temobj = new BranchModel();
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;

            using (SqlConnection con = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("sp_GetBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    temobj.Id = Convert.ToInt32(sdr["Id"].ToString());
                    //temobj.ClaimDate = Convert.ToDateTime(sdr["ClaimDate"].ToString());
                    temobj.Name = Convert.ToString(sdr["Name"]);


                    temobj.Address = Convert.ToString(sdr["Address"]);
                    temobj.Mobile = Convert.ToString(sdr["Mobile"]);
                    temobj.Email = Convert.ToString(sdr["Email"]);
                }
            }
            return temobj;
        }

        //To Delete the record on a particular Customer    
        public void DeleteCustomer(int? id)
        {
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteBranchMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
