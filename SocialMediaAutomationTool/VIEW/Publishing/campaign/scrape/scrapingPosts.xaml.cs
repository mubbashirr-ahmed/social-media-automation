using Finisar.SQLite;
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
using SocialMediaAutomationTool.CONTROLLER;

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign.scrape
{
    /// <summary>
    /// Interaction logic for scrapingPosts.xaml
    /// </summary>
    public partial class scrapingPosts : Window
    {
        string link;
        Api api;
        string unameapi="";
        string upassapi="";
        int id;
        int CID;
        string type;
        public scrapingPosts() {
            InitializeComponent();
        }
        public scrapingPosts(int id, string link, string type, int CID)
        {
            InitializeComponent();
            this.link = link;
            this.id = id;
            this.CID = CID;
            this.type = type;
            api = new Api();
            showdata(id);          
        }
        public void showdata(int id)
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            string cmd = "SELECT email, pass FROM accountdata WHERE accounttype = " + id;
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable("accoutdata");
            adp.SelectCommand = sQLiteCommand;
            dataTable.Clear();
            adp.Fill(dataTable);
            userdata.ItemsSource = dataTable.DefaultView;
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }
        private void bStartScrape(object sender, RoutedEventArgs e)
        {
                      
            if (unameapi == "---" || unameapi == "")
            {
                MessageBox.Show("Select atleast one profile!");
                return;
            }
            else if (num_posts.Text.Equals(""))
            {
                MessageBox.Show("Number of posts can't be empty!");
                return;
            }
            else
            {
                int num = Convert.ToInt32(num_posts.Text);
                if(num == 0)
                {
                    MessageBox.Show("Number of posts can't be 0!");
                    return ;
                }
                else
                {
                    if(id == 1)
                    {
                        api.scrapeMedia(unameapi, upassapi, link, num, "facebook", type, CID);
                        this.Close();
                    }
                    else if(id == 2)
                    {
                        this.Close();
                        api.scrapeMedia(unameapi, upassapi, link, num, "reddit", type, CID);          
                    }
                    else if(id == 3)
                    {
                        api.scrapeMedia(unameapi, upassapi, link, num, "pinterest", type, CID);
                        this.Close();
                    }
                    else if(id == 4)
                    {
                        api.scrapeMedia(unameapi, upassapi, link, num, "instagram", type, CID);
                        this.Close();
                    }
                    else if(id == 5)
                    {
                        api.scrapeMedia(unameapi, upassapi, link, num, "twitter", type, CID);
                        this.Close();
                    }
                }               
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            lUname.Content = dv["email"].ToString(); 
            lPass.Content = dv["pass"].ToString();
            unameapi = lUname.Content.ToString();
            upassapi = lPass.Content.ToString();            
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
    }
}
