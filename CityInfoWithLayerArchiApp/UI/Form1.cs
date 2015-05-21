using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CityInfoWithLayerArchiApp.BLL;
using CityInfoWithLayerArchiApp.Model;

namespace CityInfoWithLayerArchiApp
{
    public partial class Form1 : Form
    {
        CityManager manager=new CityManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            City aCity=new City();
            aCity.Name = cityNameTextBox.Text;
            aCity.About = aboutTextBox.Text;
            aCity.Country = countryTextBox.Text;

           string message= manager.Save(aCity);
            MessageBox.Show(message);
        }
    }
}
