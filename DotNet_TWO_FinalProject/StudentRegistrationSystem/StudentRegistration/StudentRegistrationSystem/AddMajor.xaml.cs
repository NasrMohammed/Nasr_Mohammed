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
    /// Interaction logic for AddMajor.xaml
    /// </summary>
    public partial class AddMajor : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddMajor()
        {
            InitializeComponent();
        }

        private void btnAddMajor_Click(object sender, RoutedEventArgs e)
        {
            string  majorID, majorName;


            majorID = txtMajorID.Text;
            majorName = txtMajorName.Text;
           

            try
            {
                myStudentManager.AddNewMajor( majorID, majorName);
                DisplayMajorData();

            }
            catch (Exception)
            {
                throw;
            }

        }

        private void Major_Click(object sender, RoutedEventArgs e)
        {
            DisplayMajorData();
        }
        private void DisplayMajorData()
        {
            try
            {
                var majors = myStudentManager.GetMajorsList();

               grdMajors.ItemsSource = majors;

               
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
