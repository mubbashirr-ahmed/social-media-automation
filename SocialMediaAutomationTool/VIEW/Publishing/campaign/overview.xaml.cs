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
using Finisar.SQLite;
using System.Data.SqlClient;


namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for overview.xaml
    /// </summary>
    public partial class overview : Page
    {
        public overview()
        {
            InitializeComponent();
            fill_combo();
        }
        void fill_combo()
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            //SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            //sQLiteConnection.Open();
            string cmd = "select * from Campaign";
           // SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter sQliteDataAdapter = new SQLiteDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            try
            {
                sQliteDataAdapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    campaigns.Items.Add(row["CName"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
