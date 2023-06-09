using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SocialMediaAutomationTool.DAO;
using SocialMediaAutomationTool.CONTROLLER;
using System.IO;
using System.Net;

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for drafts.xaml
    /// </summary>
    public partial class drafts : Page
    {
        int CID;
        string platform;
        public drafts(int CID)
        {
            InitializeComponent();
            this.CID = CID;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            platform = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content.ToString();
            string cmd = "Select * from " + platform + " where cID = " + CID;
            AutomationDB automationDB = new AutomationDB();
            automationDB.Displaydatadrid(cmd, draftPostGrid, platform);
        }
        private void draftPosting(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            string imgURl = dv["img"].ToString();
            string vidURl = dv["vid"].ToString();
            string username = dv["username"].ToString();
            string title = dv["title"].ToString();
            string desc = dv["description"].ToString();
            string pathF = "";
            string td = DateTime.Now.ToString("dd-MMM-yyyy");
            string path = AppDomain.CurrentDomain.BaseDirectory + "Media" + "\\" + platform + "\\" + username + "\\" + td + "\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                directory.Create();       
            }           
            if (!String.IsNullOrEmpty(imgURl))
            {       
                pathF = downloadFile(imgURl, directory, ".png");            
            }             
            if (!String.IsNullOrEmpty(vidURl))
            {          
                pathF = downloadFile(vidURl, directory, ".mp4");              
            }
            string cmd = "insert into post_list(title, Message, media, cID) values ('" + title + "','" + desc + "','" + pathF + "','" + CID + "')";
            AutomationDB db = new AutomationDB();
            db.Query(cmd, "");
            //remove from drafts
        }
        private string downloadFile(string imgURl, DirectoryInfo directory, string ext)
        {
            string[] part1 = imgURl.Split('?');
            string[] part2 = part1[0].Split('/');
            string[] name = part2[part2.Length - 1].Split('.');
            string finalpath = directory + name[0] + ext;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new Uri(imgURl), finalpath
                    );
                MessageBox.Show("Downloaded and added to post list!");
                return finalpath;
            }
        }
        private void downloadVideo(string vidURL, DirectoryInfo directory, string ext)
        {
            string[] part1 = vidURL.Split('?');
            string[] part2 = part1[0].Split('/');
            string[] name = part2[part2.Length - 1].Split('.');
            string finalpath = directory + name[0] + ext;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(
                    new Uri(vidURL), finalpath
                    );
                MessageBox.Show("Downloaded!");
            }
        }
    }
}
