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
using Finisar.SQLite;
using System.Data.SqlClient;
using System.Data;


namespace SocialMediaAutomationTool.VIEW.Publishing.campaign.scrape
{
    /// <summary>
    /// Interaction logic for scrapeposts.xaml
    /// </summary>
    public partial class scrapeposts : Page
    {
        DataGrid dataGrid;
        int cid;      
        public scrapeposts(int cid)
        {
            InitializeComponent();
            this.cid = cid;
            dataGrid = scrapeData;
            showdata();
        }
        private void bPinterestSource(object sender, RoutedEventArgs e)
        {
            addsourceD addsource;
            addsource = new addsourceD(3, dataGrid);
            addsource.Owner = Application.Current.MainWindow;
            addsource.Show();
            showdata();
        }
        private void bTwitterSource(object sender, RoutedEventArgs e)
        {
            addsourceD addsource;
            addsource = new addsourceD(5, dataGrid);
            addsource.Owner = Application.Current.MainWindow;
            addsource.Show();
            showdata();
        }
        private void bFacebookSource(object sender, RoutedEventArgs e)
        {
            addsourceD addsource;
            addsource = new addsourceD(1, dataGrid);
            addsource.Owner = Application.Current.MainWindow;
            addsource.Show();
            showdata();
        }
        private void bRedditSource(object sender, RoutedEventArgs e)
        {
            addsourceD addsource;
            addsource = new addsourceD(2, dataGrid);
            addsource.Owner = Application.Current.MainWindow;
            addsource.Show();
            showdata();
        }
        private void bInstagramSource(object sender, RoutedEventArgs e)
        {
            addsourceD addsource;
            addsource = new addsourceD(4,dataGrid);
            addsource.Owner = Application.Current.MainWindow;
            addsource.Show();
            showdata();
        }
        public void showdata()
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            string cmd = "Select * from links";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable("links");
            adp.SelectCommand = sQLiteCommand;
            dataTable.Clear();
            adp.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }      
        private void scrapedata(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            string Atype = dv["id"].ToString();
            string link = dv["url"].ToString();
            string type = dv["type"].ToString();
            int accountID = 0;

            switch(Atype)
            {
                case "Facebook":
                    accountID = 1;
                    break;
                case "Reddit":
                    accountID = 2;
                    break;
                case "Pinterest":
                    accountID = 3;
                    break;
                case "Instagram":
                    accountID = 4;
                    break;
                case "Twitter":
                    accountID = 5;
                    break;
            }
            scrapingPosts sp = new scrapingPosts(accountID, link, type, cid);
            sp.Owner = Application.Current.MainWindow;
            sp.Show();
        }
    }
}
