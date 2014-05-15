using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace Login_WPF
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    { 

        public Registration()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MembershipCreateStatus createStatus;

            MembershipUser newUser = Membership.CreateUser(txtBoxUsername.Text
                , passwordBox.Password, txtBoxEmail.Text
                , txtBoxSecurityQuestion.Text, txtBoxSecAnswer.Text, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    errormessage.Text = "The user account was succesfully created!";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    errormessage.Text = "There already exists a user with this username.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    errormessage.Text = "There already exists a user with this email address.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    errormessage.Text = "The email address you provided is invalid.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    errormessage.Text = "The security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    errormessage.Text = "The password you provided is invalid.";
                    break;
                default:
                    errormessage.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}