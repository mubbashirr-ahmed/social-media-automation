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

namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for publish.xaml
    /// </summary>
    public partial class publish : Page
    {
        Frame up, bottom;
        public publish(Frame up, Frame bottom)
        {
            InitializeComponent();
            this.up = up;
            this.bottom = bottom;
            
            showdata();
        }
        
        public void showdata()
        {           
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            string cmd = "Select * from Campaign";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable("Campaign");
            adp.SelectCommand = sQLiteCommand;
            dataTable.Clear();
            adp.Fill(dataTable);
            datagrid.ItemsSource = dataTable.DefaultView;       
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }
        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            int CID = Convert.ToInt32(dv["CID"].ToString());
            string Cname = dv["CType"].ToString();
            if (Cname == "Standard")
            {
                up.NavigationService.Navigate(new campaign_control(up, bottom, CID));
                bottom.NavigationService.Navigate(new campaign.overview());
            }
            else if (Cname == "Scheduled")
            {
                up.NavigationService.Navigate(new camapignControlScheduled(up, bottom, CID));
                bottom.NavigationService.Navigate(new campaign.overview());
            } 
        }
    }
}
