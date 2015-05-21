using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CityInfoWithLayerArchiApp.Model;

namespace CityInfoWithLayerArchiApp.DAL
{
    class CityGateway
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["CityInfoConnString"].ConnectionString;
        public int Save( City aCity)
        {
           
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Insert Into cityInfo_tbl values('" + aCity.Name + "','" + aCity.About + "','" +
                           aCity.Country + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rawAffected = command.ExecuteNonQuery();
            connection.Close();
            return rawAffected;

        
        }
    }
}
