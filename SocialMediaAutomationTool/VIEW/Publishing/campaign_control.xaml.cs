using System.Windows;
using System.Windows.Controls;
using SocialMediaAutomationTool.VIEW.Publishing.campaign;

namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for campaign_control.xaml
    /// </summary>
    public partial class campaign_control : Page
    {
        Frame frameup, framedown;
        int id;
        public campaign_control(Frame frameup, Frame framedown, int id){
            InitializeComponent();
            this.frameup = frameup;
            this.framedown = framedown;
            this.id = id;
        }
        private void bOverview(object sender, RoutedEventArgs e){
            framedown.NavigationService.Navigate(new overview());
        }

        private void bWhatpublish(object sender, RoutedEventArgs e){
            framedown.NavigationService.Navigate(new whattopublish(id));
        }

        private void bWherepublish(object sender, RoutedEventArgs e){
            framedown.NavigationService.Navigate(new wheretopublish());
        }

        private void bWhenpublish(object sender, RoutedEventArgs e){
            framedown.NavigationService.Navigate(new whentopublish());
        }

        private void bDrafts(object sender, RoutedEventArgs e){
            framedown.NavigationService.Navigate(new drafts(id));
        }

        private void bPostList(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new postslist(id, framedown));
        }
        private void bHistory(object sender, RoutedEventArgs e)
        {
            framedown.NavigationService.Navigate(new history());
        }
        
    }
}
