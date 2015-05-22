using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public bool IsCityExist(City aCity)
        {
            bool isCityExist = false;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM cityInfo_tbl where city=' "+aCity.Name+"'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                isCityExist = true;
                break;
            }
            reader.Close();
            connection.Close();
            return isCityExist;
        }

        public List<City> LoadCities()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM cityInfo_tbl";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<City> cityList = new List<City>();
            while (reader.Read())
            {
                City city=new City();
                city.Name = reader["city"].ToString();
                city.About = reader["about"].ToString();
                city.Country = reader["country"].ToString();

                cityList.Add(city);
                
            }
            reader.Close();
            connection.Close();
            return cityList;
        }

      public  List<City> SearchByCity(City acity)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM cityInfo_tbl WHERE city like '"+acity.Name+"%'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<City> cityList = new List<City>();
            while (reader.Read())
            {
                City city = new City();
                city.Name = reader["city"].ToString();
                city.About = reader["about"].ToString();
                city.Country = reader["country"].ToString();

                cityList.Add(city);

            }
            reader.Close();
            connection.Close();
            return cityList; 
        }

       public List<City> SearchByCountry(City acity)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM cityInfo_tbl WHERE country like '" + acity.Country + "%'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<City> cityList = new List<City>();
            while (reader.Read())
            {
                City city = new City();
                city.Name = reader["city"].ToString();
                city.About = reader["about"].ToString();
                city.Country = reader["country"].ToString();

                cityList.Add(city);

            }
            reader.Close();
            connection.Close();
            return cityList;
        } 
    }
}
