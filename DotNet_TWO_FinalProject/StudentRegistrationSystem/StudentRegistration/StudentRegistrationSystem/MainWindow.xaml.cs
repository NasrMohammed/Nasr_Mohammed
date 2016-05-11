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
using BusinessObjects;
using BusinessLogic;

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccessToken _accessToken;
        private Login _login;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_accessToken == null)
            {
                _login = new Login();
                _login.AccessTokenCreatedEvent += setAccessToken;  // subscribe a listener to the login event
                if (_login.ShowDialog() == true && _accessToken != null)  // login succeeded
                {
                    // initialize the form
                    // MessageBox.Show(_accessToken.FirstName + " has logged in.");
                    this.lblMessageLine.Content = _accessToken.FirstName + " " + _accessToken.LastName + " is logged in.";
                    foreach (var r in _accessToken.Roles)
                    {
                        if (r.RoleName == "Student")
                        {
                            this.tabStudent.Visibility = Visibility.Visible;
                            this.grdStudent.Visibility = Visibility.Visible;
                            this.tabStudent.Focus();
                        }
                        else if (r.RoleName == "Registrar")
                        {
                            this.tabStudent.Visibility = Visibility.Visible;
                            this.grdStudent.Visibility = Visibility.Visible;
                            this.tabRegistrar.Visibility = Visibility.Visible;
                            this.grdRegistrar.Visibility = Visibility.Visible;
                            this.tabRegistrar.Focus();
                        }
                    }
                    this.btnLogin.Content = "Log Out";
                }
                else
                {
                    // clear the access token reference to null and updata status bar
                    _accessToken = null;
                    MessageBox.Show("Login failed.");
                }
            }
            else // someone is already logged in
            {
                _accessToken = null;
                this.tabStudent.Visibility = Visibility.Collapsed;
                this.grdStudent.Visibility = Visibility.Hidden;
                this.tabRegistrar.Visibility = Visibility.Collapsed;
                this.grdRegistrar.Visibility = Visibility.Hidden;
                this.lblMessageLine.Content = "You are not logged in.";
                this.btnLogin.Content = "Log In";
            }
        }

        private void setAccessToken(object sender, AccessToken at)  // this is a listener for a login event
        {
            if (sender == _login)
            {
                this._accessToken = at;
            }
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
           Main loginMain = new Main();
           loginMain.ShowDialog();
        }

        private void Add_Class(object sender, RoutedEventArgs e)
        {
            AddClass loginMain = new AddClass();
            loginMain.ShowDialog();
        }

        private void Add_Department(object sender, RoutedEventArgs e)
        {
            AddDepartment loginMain = new AddDepartment();
            loginMain.ShowDialog();
        }

        private void Add_Location(object sender, RoutedEventArgs e)
        {
            AddLocation loginMain = new AddLocation();
            loginMain.ShowDialog();
        }

        private void Add_Major(object sender, RoutedEventArgs e)
        {
            AddMajor loginMain = new AddMajor();
            loginMain.ShowDialog();
        }

        private void Add_Section(object sender, RoutedEventArgs e)
        {
            AddSection loginMain = new AddSection();
            loginMain.ShowDialog();
        }

        private void Add_Register(object sender, RoutedEventArgs e)
        {
            AddEnrolment loginMain = new AddEnrolment();
            loginMain.ShowDialog();
        }

        private void Drop_Class(object sender, RoutedEventArgs e)
        {
            AddEnrolment loginMain = new AddEnrolment();
            loginMain.ShowDialog();
        }
       }
    }

