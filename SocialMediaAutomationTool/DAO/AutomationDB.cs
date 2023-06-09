using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Finisar.SQLite;
namespace SocialMediaAutomationTool.DAO
{
    internal class AutomationDB
    { 
        public AutomationDB()
        {
                
        }
        public AutomationDB(string cmd, DataGrid dataGrid) 
        {
            
        }
        public void Query(string cmd, string msg)
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            try
            {
                sQLiteCommand.ExecuteNonQuery();
                if(!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                }             
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sQLiteConnection.Close();
            }         
        }
        public void Displaydatadrid(string cmd, DataGrid dataGrid, string DataTabeArg)
        {
            string conn = "Data Source=database.db;Version=3;New=False;Compress=True;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(conn);
            sQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = new SQLiteCommand(cmd, sQLiteConnection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable(DataTabeArg);
            adp.SelectCommand = sQLiteCommand;
            dataTable.Clear();
            try
            {
                adp.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGrid.ItemsSource = dataTable.DefaultView;
            adp.Update(dataTable);
            sQLiteConnection.Close();
        }
    }
}
