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

namespace SocialMediaAutomationTool.Dashboardcs
{
    /// <summary>
    /// Interaction logic for dashboard_controls.xaml
    /// </summary>
    public partial class dashboard_controls : Page
    {
        Frame f1;
        SocialMediaAutomationTool.Dashboardcs.whatsnew whatsnew;
        public dashboard_controls(Frame f)
        {
            
            InitializeComponent();
            whatsnew = new whatsnew();
            f1 = f;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f1.NavigationService.Navigate(new NavigationMenuApp.Dashboardcs.notifications());
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            f1.NavigationService.Navigate(new SocialMediaAutomationTool.Dashboardcs.summary());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            f1.NavigationService.Navigate(new NavigationMenuApp.Dashboardcs.contactsupport());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            f1.NavigationService.Navigate(whatsnew);
            
        }
    }
}
