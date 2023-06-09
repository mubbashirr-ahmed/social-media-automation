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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for postslist.xaml
    /// </summary>
    public partial class postslist : Page
    {
        int CID;
        Frame framedown;
        public postslist(int CID, Frame framedown)
        {
            InitializeComponent();
            this.CID = CID;
            this.framedown = framedown;
            showdata();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";           
            //SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            //sQLiteConnection.Open();
            //SQLiteCommand sQLiteCommand;
            //string cmd;
            //string val = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();           
            //cmd = "Select * from " + val + " where cID = " + CID;
            //sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            //SQLiteDataAdapter adp = new SQLiteDataAdapter();
            //DataTable dataTable = new DataTable(val);
            //adp.SelectCommand = sQLiteCommand;
            //dataTable.Clear();
            //try
            //{
            //    adp.Fill(dataTable);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);    
            //}                        
            //datagrid.ItemsSource = dataTable.DefaultView;
            //adp.Update(dataTable);
            //sQLiteConnection.Close();
        }
        private void showdata()
        {
            string cmd = "SELECT * FROM post_list WHERE cID = " + CID;
            string val = "post_list";
            DAO.AutomationDB automationDB = new DAO.AutomationDB();
            automationDB.Displaydatadrid(cmd, datagrid, val);
        }
        private void bDeleteAll(object sender, RoutedEventArgs e)
        {
            string cmd = "Delete from post_list";
            DAO.AutomationDB automationDB = new DAO.AutomationDB();
            automationDB.Query(cmd, "All posts Deleted!");
            showdata();
        }
        private void dataGridSelection(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            string id = dv["id"].ToString();
            string title = dv["title"].ToString();
            string Message = dv["Message"].ToString();
            string media = dv["media"].ToString();
            string CID = dv["cID"].ToString();        
            postListPopup pp = new postListPopup(Convert.ToInt32(id), title, Message, media, Convert.ToInt32(CID), framedown);
            pp.Owner = Application.Current.MainWindow;
            pp.Show();
        }

    }
}
