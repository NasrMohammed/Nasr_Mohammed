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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogic;
using BusinessObjects;

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private StudentManager myStudentManager = new StudentManager();
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayStudentData();
        }

        private void DisplayStudentData()
        {
            try
            {
                var students = myStudentManager.GetStudentList();

                grdStudents.ItemsSource = students;

                //    txtTest.Clear();
                //    for (int i = 0; i < employees.Count; i++)
                //    {
                //        txtTest.AppendText(employees[i].FirstName +
                //                        " " + employees[i].LastName +
                //                        " " + employees[i].LocalPhone);
                //        txtTest.AppendText(Environment.NewLine);
                //    }
            }
            catch (Exception)
            {
                //txtTest.AppendText(ex.Message);
            }
        }

        private void GetStudentCount_Click(object sender, RoutedEventArgs e)
        {
            Active recordType = Active.active;

            if (radAll.IsChecked == true)
            {
                recordType = Active.all;
            }
            else if (radInactive.IsChecked == true)
            {
                recordType = Active.inactive;
            }

            try
            {
                lblStudentCount.Content = "Count: + " + myStudentManager.GetStudentCount(recordType).ToString();
                //lblEmployeeCount.Content = "Count: " + myEmployeeManager.GetEmployeeCount(recordType).ToString();
            }
            catch (Exception)
            {
                lblStudentCount.Content = "Count: ???";
            }
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string username, majorID, firstName, lastName, phone, address, email;
           
           
            username = txtUserName.Text;
            majorID = txtMajorID.Text;
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            phone = txtPhone.Text;
            address = txtAddress.Text;          
            email = txtEmail.Text;
        
            try
            {
                myStudentManager.AddNewStudent(username, majorID, firstName, lastName, phone, address, email);
                DisplayStudentData();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnUpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmailAddress.Text;
            string userName = txtUserNameUp.Text;
            string firstName = txtFirstNameUp.Text;
            string lastName = txtLastNameUp.Text;
            string phone = txtPhoneUp.Text;
            string address = txtAddressUp.Text;
            string userIDText = txtUserID.Text;//txtEmployeeID.Text;
            int studentID;


            if (int.TryParse(userIDText, out studentID))
            {
                try
                {
                    myStudentManager.ChangeStudentRecord(studentID, email, userName, firstName, lastName, phone, address);
                    DisplayStudentData();
                    txtEmailAddress.Clear();
                    txtUserID.Clear();
                    txtAddressUp.Clear();
                    txtPhoneUp.Clear();
                    txtUserNameUp.Clear();
                    txtFirstNameUp.Clear();
                    txtLastNameUp.Clear();


                }
                catch (Exception ex)
                {
                    txtEmailAddress.Text = ex.Message;
                    txtLastNameUp.Text = ex.Message;
                    txtFirstNameUp.Text = ex.Message;
                    txtPhoneUp.Text = ex.Message;
                    txtAddressUp.Text = ex.Message;
                    txtUserNameUp.Text = ex.Message;
                } 
            }
        }

        private void grdStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("You selected " + ((Student)grdStudents.SelectedItem).Email.ToString());
        }

        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {

            string username, majorID, firstName, lastName, phone, address, email;


            username = txtUserName.Text;
            majorID = txtMajorID.Text;
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            phone = txtPhone.Text;
            address = txtAddress.Text;
            email = txtEmail.Text;
            int userID;
            userID = Convert.ToInt32(txtUserIDDelete.Text);
            try
            {
                myStudentManager.ChangeDeleteStudentRecord(userID);
                DisplayStudentData();
            }
            catch (Exception)
            {
                throw;
            }
                    
          
        }
    }
}
