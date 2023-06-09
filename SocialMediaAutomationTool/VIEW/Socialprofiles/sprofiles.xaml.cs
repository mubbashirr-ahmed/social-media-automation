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



namespace SocialMediaAutomationTool.VIEW.Socialprofiles
{
    /// <summary>
    /// Interaction logic for sprofiles.xaml
    /// </summary>
    public partial class sprofiles : Page
    {
        Frame framebottom, frameup;
        public sprofiles(Frame framebottom, Frame frameup)
        {
            InitializeComponent();
            showdata();
            this.framebottom = framebottom;
            this.frameup = frameup; 
        }
        public void showdata()
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            string cmd = "Select * from accountdata";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable("accoutdata");
            adp.SelectCommand = sQLiteCommand;
            dataTable.Clear();
            adp.Fill(dataTable);
            profilesgrid.ItemsSource = dataTable.DefaultView;
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }
        private void profilesgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            string type = dv["accounttype"].ToString();
            string id = dv["id"].ToString();
            string uname = dv["email"].ToString();
            string pass = dv["pass"].ToString();
            int accountID = Convert.ToInt32(id);
            int accounttype = Convert.ToInt32(type);
            popUP pu = new popUP(accounttype, accountID, uname, pass, framebottom, frameup);
            pu.Owner = Application.Current.MainWindow;
            pu.Show();                       
        }
    }
}
