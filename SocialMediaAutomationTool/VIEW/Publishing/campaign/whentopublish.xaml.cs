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
using System.Threading;

namespace SocialMediaAutomationTool.VIEW.Publishing.campaign
{
    /// <summary>
    /// Interaction logic for whentopublish.xaml
    /// </summary>
    public partial class whentopublish : Page
    {
        Timer timer;
       
        public whentopublish()
        {
            InitializeComponent();
        }
        private void b_save(object sender, RoutedEventArgs e)
        {
            int val = Convert.ToInt32(waittime.Value);

            //SetUpTimer(new TimeSpan(19, val, 00));

            int valMin = 55;
            int valMax = 59;

            SetUpTimer(valMin, valMax);
        }
        private void SetUpTimer(int valMin, int valMax)
        {

            //TimeSpan alertTime = new TimeSpan( valMin, 00, 00); uncomment this function after demo
            MessageBox.Show("Check: " + valMin);
            TimeSpan alertTime = new TimeSpan(17 , valMin, 00); //remove this after demo
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = alertTime - current.TimeOfDay;

            if (timeToGo < TimeSpan.Zero)
            {
                MessageBox.Show("Time passed Enter new Time!");
                return;  //time already passed
            }
            timer = new Timer(x =>
            {
                if(valMin>valMax)                      
                {
                    MessageBox.Show("Ends Here!");
                    return;
                }
                valMin = callAPIforPosting(valMin);
                MessageBox.Show("new val: " + valMin);
                SetUpTimer(valMin, valMax);

            }, null, timeToGo, Timeout.InfiniteTimeSpan);
        }
        private int callAPIforPosting(int valMin)
        {
            MessageBox.Show("I'm Running!");
            if(valMin==59)
            {
                return 00;
            }               
            return ++valMin;
        }

    }
}
 