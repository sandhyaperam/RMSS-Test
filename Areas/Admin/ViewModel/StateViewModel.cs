using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using InventoryApplication.Areas.Admin.Models;

namespace InventoryApplication.Areas.Admin.ViewModel
{
    public class StateViewModel
    {
        string connString = string.Empty;
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;
           

        }



        public  List<SelectListItem> PopulateFruits()
        {
            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;

            List<SelectListItem> items = new List<SelectListItem>();
             using (SqlConnection con = new SqlConnection(connString))
            {
                string query = " SELECT Name, id FROM CountryMaster";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Name"].ToString(),
                                Value = sdr["id"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

        public bool AddState(StateModel objModel)
        {

            connString = GetConnection().GetSection("ConnectionStrings").GetSection("MyConn").Value;

            objModel.Countrys = PopulateFruits();
            var selectedItem = objModel.Countrys.Find(p => p.Value == objModel.Countryid.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                //ViewBag.Message = "Fruit: " + selectedItem.Text;
                //ViewBag.Message += "\\nQuantity: " + fruit.Quantity;
            }

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand com = new SqlCommand("Insert_CountryMaster", connection);
            com.CommandType = CommandType.StoredProcedure;
           // com.Parameters.AddWithValue("@Name", objModel.Name);


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
    }
}
