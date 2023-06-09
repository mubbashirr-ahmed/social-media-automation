using System;
using System.Collections.Generic;
using System.Data;
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

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for PostLocation.xaml
    /// </summary>
    
    public partial class PostLocation : Window
    {
        string val, username, password, title, Message;
        string Fpath;
        string[] media;
        bool check;
        public PostLocation(string Fpath)
        {
            InitializeComponent();
            this.Fpath = Fpath;
            check = false;
        }
        public PostLocation(string title, string Message, string[] media)
        {
            InitializeComponent();
            check = true;
            this.title = title;
            this.Message = Message;
            this.media = media;
        }
        private void selectPlatform(object sender, SelectionChangedEventArgs e)
        {          
            string cmd;
            int id = 0;
            val = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();
            switch(val)
            {
                case "Facebook":
                    id = 1;
                    break;
                case "Reddit":
                    id = 2;
                    break;
                case "Pinterest":
                    id = 3;
                    break;
                case "Instagram":
                    id = 4;
                    break;
                case "Twitter":
                    id = 5;
                    break;
            }
            cmd = "Select email, pass from accountdata where accounttype = " + id;
            DAO.AutomationDB automation = new DAO.AutomationDB();
            automation.Displaydatadrid(cmd, locationGrid, "accountdata");                    
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dataGridSelection(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            username = dv["email"].ToString();
            password = dv["pass"].ToString();
            uname.Content = username;
            pass.Content = password;
        }
        private void publish_click(object sender, RoutedEventArgs e)
        {
            if (uname.Content.ToString() == "-----" || pass.Content.ToString() == "-----")
            {
                MessageBox.Show("Select atleast one profile!");
                return;
            }
            this.Close();
            CONTROLLER.Api api = new CONTROLLER.Api();
            if(!check) //for folder
            {
                //api.postDATA(username, password, val, Fpath, null);
                return;
            }
            api.postDATA(username, password, val, "", media, title, Message); 
        }
    }
}
