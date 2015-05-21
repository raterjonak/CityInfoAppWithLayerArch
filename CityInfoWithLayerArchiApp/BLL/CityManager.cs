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
            int value = gateway.Save(aCity);
            if (value>0)
            {
                return "Data save successfully.";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
