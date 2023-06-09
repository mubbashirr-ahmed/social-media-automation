using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using SocialMediaAutomationTool.DAO;


namespace SocialMediaAutomationTool.VIEW.Publishing.campaign.scrape
{
    /// <summary>
    /// Interaction logic for MonitorFolder.xaml
    /// </summary>
    public partial class MonitorFolder : Page
    {
        public MonitorFolder()
        {
            InitializeComponent();
            showdata();
        }
        private void browse(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            {
                dialog.Description = "Time to select a folder";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string path = dialog.SelectedPath;
                    string[] files = Directory.GetFiles(path);
                    tb_path.Text = path;
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
        private void bAddfolder(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb_path.Text))
            {
                System.Windows.MessageBox.Show("Select a Path for folder!");
                return;
            }
            string cmd = "Insert into FolderPath (Path) values ('" + tb_path.Text + "')";
            AutomationDB automationDB = new AutomationDB();
            automationDB.Query(cmd, "Folder Added!");
            showdata();
        }
        public void showdata()
        {
            AutomationDB automation = new AutomationDB();
            string cmd = "Select Path from FolderPath";
            automation.Displaydatadrid(cmd, foldergrid, "Path");
        }
        private void dataGridClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.DataGrid dg = (System.Windows.Controls.DataGrid)sender;
            DataRowView dv = dg.SelectedItem as DataRowView;
            string fpath = dv["Path"].ToString();
            PostLocation postLocation = new PostLocation(fpath);
            postLocation.Owner = System.Windows.Application.Current.MainWindow;
            postLocation.Show();
        }
    }
}
