using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityInfoWithLayerArchiApp.DAL;
using CityInfoWithLayerArchiApp.Model;

namespace CityInfoWithLayerArchiApp.BLL
{
    class CityManager
    {
        CityGateway gateway=new CityGateway();

        public string Save(City aCity)
        {
            //if (aCity.Name == null)
            //{
            //    return "Please insert the city name.";
            //}
            //else
            //{

            if (gateway.IsCityExist(aCity))
                {
                    return "The city name already exist.";
                }
                else
                {


                    int value = gateway.Save(aCity);
                    if (value > 0)
                    {
                        return "Data save successfully.";
                    }
                    else
                    {
                        return "Fail";
                    }

                 }
            
                
           // }
        }

       public List<City> LoadAllCities()
       {
           return gateway.LoadCities();
       }

        public List<City> SearchByCities(City aCity)
        {
            return gateway.SearchByCity(aCity);
        }
        public List<City> SearchByCountry(City aCity)
        {
            return gateway.SearchByCountry(aCity);
        } 
    }
}
