using Finisar.SQLite;
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
using SocialMediaAutomationTool.DAO;
using System.Data;

namespace SocialMediaAutomationTool.VIEW.Socialprofiles
{
    /// <summary>
    /// Interaction logic for popUP.xaml
    /// </summary>
    public partial class popUP : Window
    {
        int id, platform;
        string uname, pass;
        Frame framebottom, frameup;
        public popUP(int platform, int id, string uname, string pass, Frame framebottom, Frame frameup)
        {
            InitializeComponent();
            this.id = id;
            this.platform = platform;
            this.uname = uname;
            this.pass = pass;
            this.framebottom = framebottom;
            this.frameup = frameup;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void bDelete(object sender, RoutedEventArgs e)
        {

            if(MessageBox.Show("Do you really want to delete record?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {               
                string cmd = "Delete from accountdata where id=" + id;
                AutomationDB automationDB = new AutomationDB();
                automationDB.Query(cmd, "Profile Deleted Successfully");               
            }            
            this.Close();
            
        }

        private void bUpdate(object sender, RoutedEventArgs e)
        {
            this.Close();
            frameup.NavigationService.Navigate(new fbaddprofiles.fbsettings(platform, id, uname, pass, true));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, platform));
        }
     
    }
}
