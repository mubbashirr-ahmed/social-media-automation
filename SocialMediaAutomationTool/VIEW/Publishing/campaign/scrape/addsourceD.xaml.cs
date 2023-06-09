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
using Finisar.SQLite;
using System.Data.SqlClient;
using SocialMediaAutomationTool.DAO;
using SocialMediaAutomationTool.VIEW.Publishing.campaign;

using System.Data;
using System.Windows.Navigation;



namespace SocialMediaAutomationTool.VIEW.Publishing.campaign.scrape
{
    /// <summary>
    /// Interaction logic for addsourceD.xaml
    /// </summary>
    public partial class addsourceD : Window
    {
        int id;
        string url;
        string Atype;
        DataGrid datagrid;

        public addsourceD(int id, DataGrid datagrid)
        {
            InitializeComponent();
            this.id = id;
            this.datagrid = datagrid;
            if (id == 1)
            {
                user.Visibility = Visibility.Visible;
                group.Visibility = Visibility.Visible;
                Atype = "Facebook";
            }
            else if (id == 2)
            {
                user.Visibility = Visibility.Visible;
                search.Visibility = Visibility.Visible;
                subreddit.Visibility = Visibility.Visible;
                Atype = "Reddit";
            }
            else if (id == 3)
            {
                user.Visibility = Visibility.Visible;
                search.Visibility = Visibility.Visible;
                //board.Visibility = Visibility.Visible;
                Atype = "Pinterest";
            }
            else if (id == 4)
            {
                user.Visibility = Visibility.Visible;               
                hashtag.Visibility = Visibility.Visible;
                Atype = "Instagram";
            }
            else if (id == 5)
            {
                user.Visibility = Visibility.Visible;
                search.Visibility = Visibility.Visible;
                Atype = "Twitter";
            }
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }
        private void bAddSubreddit(object sender, RoutedEventArgs e)
        {
            database("subreddit");
        }
        private void bAddGroup(object sender, RoutedEventArgs e)
        {
            database("group");
        }
        private void bAddBoard(object sender, RoutedEventArgs e)
        {
            database("board");
        }
        private void bAddSearch(object sender, RoutedEventArgs e)
        {
            database("search");
        }
        private void bAddHashtag(object sender, RoutedEventArgs e)
        {
            database("hashtag");
        }
        private void bAddUser(object sender, RoutedEventArgs e)
        {
            database("user");
        }
        private void database(string type)
        {
            url = tURL.Text;
            if (url == "")
            {
                MessageBox.Show("enter atleast one link!");
            }
            else
            {
                string cmd = " insert into links values('" + Atype + "','" + url + "','"+ type + "')";
                AutomationDB automationDB = new AutomationDB();
                automationDB.Query(cmd, "Source Added");
                this.Close();
                showdata();
            }
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
            datagrid.ItemsSource = dataTable.DefaultView;
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }
    }
}
