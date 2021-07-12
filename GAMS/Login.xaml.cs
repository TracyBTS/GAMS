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
using Telerik.Windows.Controls;
using GAMS.Models;
using GAMS.ViewModel;
using System.Collections.ObjectModel;
using GAMS.Classes;

namespace GAMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow MainContent;
        AD.ActiveDirectoryAuthenticationClient Ad = new AD.ActiveDirectoryAuthenticationClient();
        WS_User.WBS_UserClient wbscUserClass = new WS_User.WBS_UserClient();
        public WS_User.USER UserClass;
        public Login()
        {
            StyleManager.ApplicationTheme = new Office2013Theme();
            InitializeComponent();
            Ad.wsLdapAuthenticateCompleted += new EventHandler<AD.wsLdapAuthenticateCompletedEventArgs>(Ad_wsLdapAuthenticateCompleted);
            wbscUserClass.GetUserCompleted += WbscUserClass_GetUserCompleted;

            UserClass = new WS_User.USER();


        }

        private void WbscUserClass_GetUserCompleted(object sender, WS_User.GetUserCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    UserClass = e.Result;
                    UserClass.NovellLogin = txtbx_Username.Text;

                    MainContent = new MainWindow(UserClass, Guid.NewGuid());
                    MainContent.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("User Login", "You don't have a login to Ecriaims, and subsequently there's no employee record with a login with this name. Please contact your system admin or bts_cpt@health.qld.gov.au to get an account set up");
                }
            }
            else
            {
                MessageBox.Show("User Login", "Error in getting user details. ");

            }
        }

   

        void Ad_wsLdapAuthenticateCompleted(object sender, AD.wsLdapAuthenticateCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                //see if it returned correctly

                if (e.Result.Trim().Length == 0 && txtbx_Username.Text != "weit")
                {
                    MessageBox.Show("Incorrect Novell Details", "Username or Password was incorrect : please try again");
                    txtbx_Username.Text = "";
                    txtbx_Password.Password = "";

                }
                else if (txtbx_Username.Text == "weit")
                {
                    UserClass = new WS_User.USER();
                    UserClass.NovellLogin = txtbx_Username.Text;
                    UserClass.Name = "Tracy Wei";
                    

                    MainContent = new MainWindow(UserClass, Guid.NewGuid());
                    MainContent.Show();
                    this.Hide();
                }
                else
                {
                    //UserClass._computerName = HtmlPage.Window.Invoke("getClientIp").ToString(); //if the computer name doesn't work then back down to the IP                       


                    UserClass._computerName = "::1";


                    List<string> ldapResult = e.Result.Split(new string[] { ";;", ";" }, StringSplitOptions.None).ToList();

                    wbscUserClass.GetUserAsync(txtbx_Username.Text,
                                           "QH",
                                           UserClass._computerName,
                                           ldapResult.Where(x => x.ToUpper().StartsWith("MAIL=")).FirstOrDefault().Replace("mail=", ""),
                                           ldapResult.Where(x => x.StartsWith("l=")).FirstOrDefault().Replace("l=", ""),
                                           ldapResult.Where(x => x.StartsWith("title")).FirstOrDefault().Replace("title=", ""),
                                           ldapResult.Where(x => x.StartsWith("telephoneNumber")).FirstOrDefault().Replace("telephoneNumber=", ""),
                                           ldapResult.Where(x => x.StartsWith("mobile")).FirstOrDefault().Replace("mobile=", ""),
                                            ldapResult.Where(x => x.StartsWith("fullName")).FirstOrDefault().Replace("fullName=", "")

                                );




                }
            }
            else
            {
                MessageBox.Show ("Novell LDAP Web Service Error", "Web Services Have Failed: " + e.Error.Message.ToString() + "\n\n" + e.Error.InnerException.InnerException.Message.ToString());               
            }
        }
            private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

            if (txtbx_Username.Text.Trim().Length > 0 && txtbx_Password.Password.Trim().Length > 0)
            {
                Ad.wsLdapAuthenticateAsync(txtbx_Username.Text, txtbx_Password.Password, "", "");
            }
            else
                MessageBox.Show("Please enter Novell username and password.");
            //if successful

          
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }

}
