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

namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for testscreen.xaml
    /// </summary>
    public partial class campaigntype : Window
    {
        Frame framedown,frameup;
        public campaigntype(Frame framedown, Frame frameup)
        {
            InitializeComponent();
            this.framedown = framedown;
            this.frameup = frameup;  
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bScheduled(object sender, RoutedEventArgs e)
        {
            this.Close();
            GetNamePop pp = new GetNamePop(frameup, framedown, "Scheduled");
            pp.Show();
        }

        private void bStandard(object sender, RoutedEventArgs e)
        {
            this.Close();
            GetNamePop pp = new GetNamePop(frameup, framedown, "Standard");
            pp.Show();
        }
    }
}
