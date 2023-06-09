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
using SocialMediaAutomationTool.VIEW.Publishing.campaign;

namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for camapignControlScheduled.xaml
    /// </summary>
    public partial class camapignControlScheduled : Page
    {
        Frame frameup, framedown;
        int id;
        public camapignControlScheduled(Frame frameup, Frame framedown, int id)
        {
            InitializeComponent();
            this.frameup = frameup;
            this.framedown = framedown;
            this.id = id;
        }
        private void bOverview(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new overview());
        }

        private void bWhatpublish(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new whattopublish(id));
        }

        private void bWherepublish(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new wheretopublish());
        }
        private void bPostList(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new postslist(id, framedown));
        }

        private void bDrafts(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new drafts(id));
        }
        private void bHistory(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new history());

        }
    }
}
