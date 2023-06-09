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

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for whattopublish.xaml
    /// </summary>
    public partial class whattopublish : Page
    {
        int Cid;
        public whattopublish(int Cid)
        {
            InitializeComponent();
            this.Cid = Cid;   
        }

        private void bAddpost(object sender, RoutedEventArgs e)
        {
            wframe.NavigationService.Navigate(new scrape.addposts(Cid));
        }

        private void bScrapeposts(object sender, RoutedEventArgs e)
        {
            wframe.NavigationService.Navigate(new scrape.scrapeposts(Cid));
        }

        private void bRSSposts(object sender, RoutedEventArgs e)
        {
            wframe.NavigationService.Navigate(new scrape.rssposts());
        }

        private void bMonitor(object sender, RoutedEventArgs e)
        {
            wframe.NavigationService.Navigate(new scrape.MonitorFolder());
        }
    }
}
