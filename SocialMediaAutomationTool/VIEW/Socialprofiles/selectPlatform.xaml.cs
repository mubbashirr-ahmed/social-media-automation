using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Finisar.SQLite;

namespace SocialMediaAutomationTool.VIEW.Socialprofiles
{
    /// <summary>
    /// Interaction logic for selectPlatform.xaml
    /// </summary>
    public partial class selectPlatform : Window
    {
        Frame frametop;
        Frame framebottom;
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\integers.txt";
        string filenameCSV;
        OpenFileDialog openDG;
        public selectPlatform(Frame frametop, Frame framebottom)
        {
            InitializeComponent();
            this.frametop = frametop;
            this.framebottom = framebottom; 

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void fb_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frametop.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, 1));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fbsettings(1, false));
        } 
        private void RD_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frametop.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, 2));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fbsettings(2, false));
        }
        private void IG_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frametop.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, 4));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fbsettings(4, false));
        }
        private void PT_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frametop.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, 3));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fbsettings(3, false));
        }
        private void TW_add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            frametop.NavigationService.Navigate(new fbaddprofiles.fb_control(framebottom, 5));
            framebottom.NavigationService.Navigate(new fbaddprofiles.fbsettings(5, false));
        }      
        private void fImport(object sender, RoutedEventArgs e)
        {
            openDG = opendialogbox();
            openDG.ShowDialog();
            filenameCSV = openDG.FileName;            
            if(File.Exists(filenameCSV))
            {
                readCSV(1, filenameCSV);
                filenameCSV = "";
            }           
        }
        private void RDImport(object sender, RoutedEventArgs e)
        {
            openDG = opendialogbox();
            openDG.ShowDialog();
            filenameCSV = openDG.FileName;
            if (File.Exists(filenameCSV))
            {
                readCSV(2, filenameCSV);
                filenameCSV = "";
            }
        }
        private void Pimport(object sender, RoutedEventArgs e)
        {
            openDG = opendialogbox();
            openDG.ShowDialog();
            filenameCSV = openDG.FileName;
            if (File.Exists(filenameCSV))
            {
                readCSV(4, filenameCSV);
                filenameCSV = "";
            }
        }
        private void IGImport(object sender, RoutedEventArgs e)
        {
            openDG = opendialogbox();
            openDG.ShowDialog();
            filenameCSV = openDG.FileName;
            if (File.Exists(filenameCSV))
            {
                readCSV(3, filenameCSV);
                filenameCSV = "";
            }
        }
        private void TIpmort(object sender, RoutedEventArgs e)
        {
            openDG = opendialogbox();
            openDG.ShowDialog();
            filenameCSV = openDG.FileName;
            if (File.Exists(filenameCSV))
            {
                readCSV(5, filenameCSV);
                filenameCSV = "";
            }
        }
        private OpenFileDialog opendialogbox()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = false;
            fd.Filter = "CSV|*.csv|Textfiles|*.txt|All Files|*.*";
            fd.DefaultExt = ".csv";            
            return fd;
        }
        private bool readCSV(int platform, string filename)
        {
            SQLiteCommand sQLiteCommand;
            int num;
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            int ln = 0;
            using (StreamReader reader = new StreamReader(filename))
            {                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (ln!=0)
                    {
                        num = readvalue();
                        if (num == 0)
                        {
                            return false;
                        }
                        string cmd = " insert into accountdata values('" + platform + "','" + num + "','" + values[0] + "','" + values[1] + "')";
                        sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
                        try
                        {
                            sQLiteCommand.ExecuteNonQuery();
                            System.Windows.MessageBox.Show("Stored" + num); //remove
                            num++;
                            writevalue(num);
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.MessageBox.Show("Username " + values[0] + " was already imported!");
                        }
                    }
                    ln++;
                }
            }           
            sQLiteConnection.Close();
            return true;
        }
        private void writevalue(int num)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, Convert.ToString(num));                
            }
            else
            {
                System.Windows.MessageBox.Show("Error writing to file!");
            }
        }
        private int readvalue()
        {
            int val = 0;
            if (File.Exists(path))
            {
                string num = File.ReadAllText(path);              
                val = Convert.ToInt32(num);
            }
            else
            {
                System.Windows.MessageBox.Show("Error reading File!");
                val = 0;
            }
            return val;
        }       
    }
}
