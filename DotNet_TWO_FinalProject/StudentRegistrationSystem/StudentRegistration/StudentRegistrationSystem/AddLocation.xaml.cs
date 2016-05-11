using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogic;
using BusinessObjects;

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddLocation()
        {
            InitializeComponent();
        }

        private void btnAddLocation_Click(object sender, RoutedEventArgs e)
        {
            string locationID, locationName;


            locationID = txtLocationID.Text;
            locationName = txtLocationName.Text;


            try
            {
                myStudentManager.AddNewLocation(locationID, locationName);
                DisplayLocationData();

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            DisplayLocationData();
        }
        private void DisplayLocationData()
        {
            try
            {
                var locations = myStudentManager.GetLocationList();

                grdLocations.ItemsSource = locations;


            }
            catch (Exception)
            {

            }
        }

        private void grdStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
