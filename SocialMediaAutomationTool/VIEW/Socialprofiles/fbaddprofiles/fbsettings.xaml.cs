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
using Finisar.SQLite;
using System.Data.SqlClient;
using System.IO;
using SocialMediaAutomationTool.CONTROLLER;
using SocialMediaAutomationTool.DAO;

namespace SocialMediaAutomationTool.VIEW.Socialprofiles.fbaddprofiles
{
    /// <summary>
    /// Interaction logic for fbsettings.xaml
    /// </summary>
    public partial class fbsettings : Page
    {
        int platform;
        int ID;
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\integers.txt";
        Api api;
        bool ifUpdate;
        public fbsettings(int platform, bool ifUpdate)
        {
            InitializeComponent();
            this.platform = platform;
            this.ifUpdate = ifUpdate;
            updateverify.Content = "Verify";

        }
        public fbsettings(int platform, int id, string username, string password, bool ifUpdate)
        {
            InitializeComponent();
            this.username.Text = username;
            this.password.Text = password;
            this.platform = platform;
            this.ID = id;
            api = new Api();
            this.ifUpdate = ifUpdate;
            updateverify.Content = "Update";
        }
        public void getdata()
        {
            string uname = username.Text;
            string pass = password.Text;
                 
            //bool check = api.VerifyCredential(uname, pass); needs to be implemented later
            bool check = true;

            if (check)
            {
                if (ifUpdate)
                {
                    updatedatabase(uname, pass);
                }
                else
                {
                    savetodatabase(uname, pass);
                }
            } 
            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }       
        }
        private void updatedatabase(string uname, string pass)
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            SQLiteCommand sQLiteCommand;
            try
            {
                sQLiteConnection.Open();
                string cmd = " update accountdata set accounttype = '" + platform + "', id = '" + ID + "', email = '" + uname + "', pass = '" + pass + "' where id = " + ID;
                sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
                try
                {
                    sQLiteCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully!");
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show(e.ToString());
                }
                sQLiteConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }
        private void savetodatabase(string uname, string pass)
        {
            string cmd = " insert into accountdata (accounttype, email, pass) values ('" + platform + "','" + uname + "','" + pass + "')";
            AutomationDB automationDB = new AutomationDB();
            automationDB.Query(cmd, "Profile added!");
            username.Text = "";
            password.Text = "";
        }
        private void bVerify_Click(object sender, RoutedEventArgs e)
        {
           getdata();          
        }       
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {}
        private void useraname(object sender, MouseEventArgs e)
        {
            if (username.Text.ToString() == "Username or email")
            {
                username.Text = "";
            }
        }
        private void password_(object sender, MouseEventArgs e)
        {
            if (password.Text.ToString() == "Password")
            {
                password.Text = "";
            }
            
        }
    }
}
