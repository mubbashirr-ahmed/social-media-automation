using System.Windows;
using System.Windows.Input;
using SocialMediaAutomationTool.DAO;
using SocialMediaAutomationTool.VIEW.Publishing;
using SocialMediaAutomationTool.VIEW.Socialprofiles;
using SocialMediaAutomationTool.MODEL;
using SocialMediaAutomationTool.CONTROLLER;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System;

namespace SocialMediaAutomationTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            page_name.Text = "Dashboard";
            frame.Visibility = Visibility.Visible;
            frame_button.Visibility = Visibility.Visible;
            frame_button.NavigationService.Navigate(new SocialMediaAutomationTool.Dashboardcs.dashboard_controls(frame));
            frame.NavigationService.Navigate(new SocialMediaAutomationTool.Dashboardcs.summary());

        }
        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_maximize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }
        private void Button_minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        public void open_summary(object sender, RoutedEventArgs e)
        {
            page_name.Text = "Dashboard";
            frame.Visibility = Visibility.Visible;
            frame_button.Visibility = Visibility.Visible;
            frame_button.NavigationService.Navigate(new Dashboardcs.dashboard_controls(frame));
            frame.NavigationService.Navigate(new Dashboardcs.summary());
        }
        private void open_publish(object sender, RoutedEventArgs e)
        {
            page_name.Text = "Publishing";
            frame.Visibility = Visibility.Visible;
            frame_button.Visibility = Visibility.Visible;
            frame_button.NavigationService.Navigate(new publish_control(frame_button, frame));
            frame.NavigationService.Navigate(new publish(frame_button, frame));
        }
        private void open_profiles(object sender, RoutedEventArgs e)
        {
            page_name.Text = "Profiles";
            frame.Visibility = Visibility.Visible;
            frame_button.Visibility = Visibility.Visible;
            frame_button.NavigationService.Navigate(new sprofiles_controls(frame_button, frame));
            frame.NavigationService.Navigate(new sprofiles(frame_button, frame));

        }
        private void open_proxymng(object sender, RoutedEventArgs e)
        {
            page_name.Text = "Proxy";
            frame.Visibility = Visibility.Visible;
            frame_button.Visibility = Visibility.Visible;
            frame_button.NavigationService.Navigate(new NavigationMenuApp.proxymanager.proxy_controls());
            frame.NavigationService.Navigate(new NavigationMenuApp.proxymanager.proxymanage());
        }
        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("ok");   
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] mediaArr = new string[] { "OK1", "OK2", "OK3" };
            Postdata postdata = new Postdata();
            postdata.email = "OK";
            postdata.password = "OK";
            postdata.desc = new string[] { "my first post" };
            string[,] arr2 = new string[1, mediaArr.Length - 1];
            for (int i = 0; i < mediaArr.Length - 1; i++)
            {
                arr2[0, i] = mediaArr[i];
            }
            postdata.image = arr2;
            postdata.feeling = new string[] { null };
            //postdata.tag = new string[,] { { null } };
            var json = JsonConvert.SerializeObject(postdata);
            File.WriteAllText(@"D:\ok.txt", json);
        }
        public async void task(string json)
        {
            try
            {
                var content = new StringContent(json, System.Text.Encoding.UTF32, "application/json");
                string url = "http://127.0.0.1:5000/" + "facebook/publish/user"; //place holder
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PutAsync(url, content))
                    {
                        using (HttpContent content2 = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            // HttpContentHeaders headerrs = content.Headers;
                            MessageBox.Show(mycontent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
        //public static void ATmr(object sender, ElapsedEventArgs e)
        // {
            //cnt++;
            //MessageBox.Show("Time: " + cnt);
            //if (cnt == 3)
            //{
            //    atmr.Stop();
            //    MessageBox.Show("Done");
            //    cnt = 0;
            //}    
        // }
        //private void jsons()
        //{
        //    Postdata pd = new Postdata
        //    {
        //        email = "okanything767@gmail.com",
        //        password = "12345678q@",
        //        target_user = "LinusTech",
        //        post_data = new PostD[]
        //        {
        //            new PostD()
        //            {
        //                desc = "ok",
        //                media = new string[] { "My", "first", "post" }
        //            },
        //            new PostD()
        //            {
        //                desc = "ok",
        //                media = new string[] { "My", "Second", "post" }
        //            },
        //            new PostD()
        //            {
        //                desc = "ok",
        //                media = new string[] { "My", "Third", "post" }
        //            }
        //        }
        //    };
        //    var json = JsonConvert.SerializeObject(pd);
        //    MessageBox.Show(json);
        //    File.WriteAllText(@"D:\ok.txt", json);
        //    string response = JsonConvert.SerializeObject(json);
        //    MessageBox.Show(response);
        //}
}