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

namespace SocialMediaAutomationTool.VIEW.Socialprofiles.fbaddprofiles
{
    /// <summary>
    /// Interaction logic for fb_control.xaml
    /// </summary>
    public partial class fb_control : Page
    {
        Frame frame;
        int platform;
        public fb_control(Frame frame, int platform)
        {
            InitializeComponent();
            this.frame = frame; 
            this.platform = platform;   
        }
        private void open_settings_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new fbsettings(platform, false));
        }

        private void open_groups_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new fbgroups());
        }
        private void open_ignore_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new fbignore());
        }
        private void open_friends_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new fbfriends());
        } 
        private void open_notes_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new fbnotes());
        }
    }
}
