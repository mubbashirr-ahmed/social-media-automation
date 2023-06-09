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
namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for GetNamePop.xaml
    /// </summary>
    public partial class GetNamePop : Window
    {
        Frame frameup, bottom;
        string ctype;
        public GetNamePop() { }
        public GetNamePop(Frame frameup, Frame bottom, string ctype)
        {
            InitializeComponent();
            this.frameup = frameup;
            this.bottom = bottom;
            this.ctype = ctype;
        }

        private void bOK(object sender, RoutedEventArgs e)
        {
            string name = getname.Text;
            
            if(name == "")
            {
                MessageBox.Show("Enter name for your Campaign!");
            }
            else
            {
                createCampaign(name.ToString());
            }
        }
        private void createCampaign(string name)
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();

            string cmd = "INSERT INTO Campaign (CName, CType) values ('" + name + "','" + ctype + "')";
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            try
            {
                sQLiteCommand.ExecuteNonQuery();
                MessageBox.Show("Campaign Created!");
                this.Close();
                SQLiteCommand sQLiteCommand2 = new SQLiteCommand("select CID from Campaign where CName = '" + name + "'", sQLiteConnection);
                SQLiteDataReader reader = sQLiteCommand2.ExecuteReader();
                string id;
                if (reader.Read())
                {
                    id = reader["CID"].ToString();
                    if(ctype == "Standard")
                    {
                        bottom.NavigationService.Navigate(new campaign_control(bottom, frameup, Convert.ToInt32(id)));
                        frameup.NavigationService.Navigate(new campaign.overview());
                    }
                    else if(ctype == "Scheduled")
                    {
                        bottom.NavigationService.Navigate(new camapignControlScheduled(bottom, frameup, Convert.ToInt32(id)));
                        frameup.NavigationService.Navigate(new campaign.overview());
                    }
                    
                }     
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            sQLiteConnection.Close();
        }
        private void bClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
