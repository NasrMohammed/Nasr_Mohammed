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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        AccessToken _accessToken;

        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
             // first, grab the values of the text boxes
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Password;
            string passConfirm = this.txtPassConfirm.Password;
            
            try
            {
                // decide whether to check for new user or existing user
                if (this.chkNewUser.IsChecked == true)
                {
                    if (password != passConfirm)
                    {
                        throw new ApplicationException("Passwords must match!");
                    }
                    _accessToken = SecurityManager.ValidateNewUser(username, password);
                    this.DialogResult = true;
                }
                else
                {
                    _accessToken = SecurityManager.ValidateExistingUser(username, password);
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Declare the delegate that will be the prototype of event subscribers
        public delegate void AccessTokenCreatedEventHandler(object sender, AccessToken a);

        // Declare the event from a delegate, so it knows what sort of subscribers to accept
        public event AccessTokenCreatedEventHandler AccessTokenCreatedEvent;
        protected virtual void RaiseAccessTokenCreatedEvent()  // we need a method to raise the event
        {
            // Raise the event
            if (AccessTokenCreatedEvent != null)  // if there are subscribers/listeners/handlers
                AccessTokenCreatedEvent(this, _accessToken); // go ahead and raise the event
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_accessToken != null)  // don't raise the event if no one logged in
            {
                RaiseAccessTokenCreatedEvent();
            }
        }

        private void ChkNewUser_Checked(object sender, RoutedEventArgs e)
        {
            this.txtPassConfirm.Visibility = Visibility.Visible;
            this.lblPassConfirm.Visibility = Visibility.Visible;
            this.lblPassword.Content = "Choose Password:";
        }
        private void chkNewUser_Unchecked(object sender, RoutedEventArgs e)
        {
            this.txtPassConfirm.Visibility = Visibility.Hidden;
            this.lblPassConfirm.Visibility = Visibility.Hidden;
            this.lblPassword.Content = "Password:";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtUsername.Focus();
        }
        }
    }

