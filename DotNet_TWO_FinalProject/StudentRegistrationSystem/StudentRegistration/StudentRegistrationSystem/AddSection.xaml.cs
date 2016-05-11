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
    /// Interaction logic for AddSection.xaml
    /// </summary>
    public partial class AddSection : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddSection()
        {
            InitializeComponent();
        }

        private void btnAddSection_Click(object sender, RoutedEventArgs e)
        {
            string sectionID, termID, locationID;
            int userID;

            sectionID = txtSectionID.Text;
            userID = Convert.ToInt32(txtUserID.Text);
            termID = txtTermID.Text;
            locationID = txtLocationID.Text;

            try
            {
                myStudentManager.AddNewSection(sectionID, userID, termID, locationID);
                DisplaySectionData();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Section_Click(object sender, RoutedEventArgs e)
        {
            DisplaySectionData();

        }
        private void DisplaySectionData()
        {
            try
            {
                var sections = myStudentManager.GetSectionList();

                grdSections.ItemsSource = sections;


            }
            catch (Exception)
            {

            }
        }
       }
    }

