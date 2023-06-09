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

namespace SocialMediaAutomationTool.VIEW.Publishing
{
    /// <summary>
    /// Interaction logic for publish_control.xaml
    /// </summary>
    public partial class publish_control : Page
    {
        Frame framedown, frameup;
        public publish_control(Frame framedown, Frame frameup)
        {
            InitializeComponent();
            this.framedown = framedown;
            this.frameup = frameup;
        }
        
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            campaigntype ct = new campaigntype(framedown,frameup);
            ct.Show();      
        }
    }
}
