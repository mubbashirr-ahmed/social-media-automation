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

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for postListPopup.xaml
    /// </summary>
    public partial class postListPopup : Window
    {
        int ID, CID;
        string title, Message;
        string media;
        Frame framedown;
        public postListPopup(int ID, string title, string Message, string media, int CID, Frame framedown)
        {
            InitializeComponent();
            this.ID = ID;
            this.title = title;
            this.Message = Message;
            this.media = media;
            this.CID = CID;
            this.framedown = framedown;
        }
        private void bEdit(object sender, RoutedEventArgs e)
        {
            this.Close();
            framedown.NavigationService.Navigate(new scrape.addposts(ID, title, Message, media, CID));
            //scrape.addposts addposts = new scrape.addposts(ID, title, Message, media, CID);
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void bPublishNow(object sender, RoutedEventArgs e)
        {
            if (title == "")
            {
                MessageBox.Show("Post with no Title! Edit before publishing");
                return;
            }
            string[] mediaArray = media.Split(';');
            PostLocation postLocation = new PostLocation(title, Message, mediaArray);
            postLocation.Owner = this;
            postLocation.Show();
        }
        private void bDelete(object sender, RoutedEventArgs e)
        {
            string cmd = "Delete from post_list where id = " + ID;
            DAO.AutomationDB automation = new DAO.AutomationDB();
            automation.Query(cmd, "Post Deleted!");
            this.Close();

        }
    }
}
