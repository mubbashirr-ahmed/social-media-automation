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

namespace SocialMediaAutomationTool.VIEW.Socialprofiles
{
    /// <summary>
    /// Interaction logic for sprofiles_controls.xaml
    /// </summary>
    public partial class sprofiles_controls : Page
    {
        Frame framebottom;
        Frame frametop;
        public sprofiles_controls(Frame frametop, Frame framebottom)
        {
            InitializeComponent();
            this.frametop = frametop;
            this.framebottom = framebottom; 
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            SocialMediaAutomationTool.VIEW.Socialprofiles.selectPlatform select = new SocialMediaAutomationTool.VIEW.Socialprofiles.selectPlatform(frametop, framebottom);
            select.Show();  
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
