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
    /// Interaction logic for AddClass.xaml
    /// </summary>
    public partial class AddClass : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddClass()
        {
            InitializeComponent();
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            string classID, departmentID, description, numOfSeats, className;


            classID = txtClassID.Text;
            departmentID = txtDepartmentID.Text;
            description = txtDescription.Text;
            numOfSeats = txtNumOfSeats.Text;
            className = txtClassName.Text;


            try
            {
                myStudentManager.AddNewClass (classID, departmentID, description, numOfSeats, className);
                DisplayClassData();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Major_Click(object sender, RoutedEventArgs e)
        {
            DisplayClassData();
        }
        private void DisplayClassData()
        {
            try
            {
                var classes = myStudentManager.GetClassesList();

                grdMajors.ItemsSource = classes;


            }
            catch (Exception)
            {

            }
        }

    }
}
