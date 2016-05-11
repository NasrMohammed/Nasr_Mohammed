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
    /// Interaction logic for AddEnrolment.xaml
    /// </summary>
    public partial class AddEnrolment : Window
    {
        private StudentManager myStudentManager = new StudentManager();

        public AddEnrolment()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, RoutedEventArgs e)
        {
            string enrolmentID, classID, sectionID;
            int userID;

            enrolmentID = txtEnrolmentID.Text;
            userID = Convert.ToInt32(txtUserID.Text);
            classID = txtClassID.Text;
            sectionID = txtSectionID.Text;


            try
            {
                myStudentManager.AddNewEnrolment(enrolmentID, userID, classID, sectionID);
                DisplayEnrolmentData();

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DisplayEnrolmentData()
        {
            try
            {
                var enrolls = myStudentManager.GetEnrolemtList();

                grdEnrolment.ItemsSource = enrolls;


            }
            catch (Exception)
            {

            }
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            DisplayEnrolmentData();
        }
    }
}
