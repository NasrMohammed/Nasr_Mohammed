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
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddDepartment()
        {
            InitializeComponent();
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            string departmentID, departmentName;

            departmentID = txtDepartmentID.Text;
            departmentName = txtDepartmentName.Text;
            


            try
            { 
                myStudentManager.AddNewDepartment(departmentID, departmentName);
                DisplayDepartmentData();

            
            }
            catch (Exception)
            {
                throw;
            }

        }

      
        private void Department_Click(object sender, RoutedEventArgs e)
        {
            DisplayDepartmentData();
        }
        private void DisplayDepartmentData()
        {
            try
            {
                var departments = myStudentManager.GetDepartmentList();

                grdDepartment.ItemsSource = departments;


            }
            catch (Exception)
            {

            }
        }
    }
}
