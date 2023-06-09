using Microsoft.Win32;
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
using SocialMediaAutomationTool.DAO;

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign.scrape
{
    /// <summary>
    /// Interaction logic for addposts.xaml
    /// </summary>
    public partial class addposts : Page
    {
        int CID;
        int ID;
        string imgname = "";
        bool check;
        public addposts(int CID)
        {
            InitializeComponent();
            this.CID = CID;
            check = false;
        }
        public addposts(int ID,string titl, string Message, string media, int CID)
        {
            InitializeComponent();
            title.Text = titl;
            message.Text = Message;
            this.CID = CID;
            this.ID = ID;
            imgname = media;
            bAdd.Content = "Update Post List";
            check = true;
        }
        private void bSelectPics(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpeg;*.bmp;*.jpg;*.png";
            openFileDialog.Multiselect = true;
     
            if(openFileDialog.ShowDialog() == true)
            {
                for(int i=0;i< openFileDialog.FileNames.Length;i++)
                {
                    imgname += openFileDialog.FileNames[i] + ";";
                }
                //if (imgname!="")
                //{
                //    pic.Visibility = Visibility.Visible;
                //    pic.Source = new BitmapImage(new Uri(imgname));
                //}
            }
        }
        private void bAddtoPL(object sender, RoutedEventArgs e)
        {
            string ttle = title.Text;
            string desc = message.Text;
            if(!check)
            {
                if (imgname != "")
                {
                    string cmd = "Insert into post_list (title, Message, media, cID) values ('" + ttle + "','" + desc + "','" + imgname + "','" + CID + "')";
                    AutomationDB db = new AutomationDB();
                    db.Query(cmd, "successfully entered");
                    pic.Visibility = Visibility.Hidden;
                    title.Text = "";
                    message.Text = "";
                }
                else
                {
                    MessageBox.Show("Select atleat 1 image!");
                }
                return;
            }
            string cmd1 = "UPDATE post_list SET title = '"+ ttle+ "', Message = '" + desc + "', media = '"+ imgname +"' WHERE id = " + ID;
            AutomationDB db2 = new AutomationDB();
            db2.Query(cmd1, "Updated successfully!");
            pic.Visibility = Visibility.Hidden;
            title.Text = "";
            message.Text = "";
        }
    }
}
