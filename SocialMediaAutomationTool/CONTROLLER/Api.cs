using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SocialMediaAutomationTool.MODEL;
using SocialMediaAutomationTool.DAO;
using System.Threading;

namespace SocialMediaAutomationTool.CONTROLLER
{
    internal class Api
    {
        AutomationDB automation;
        public Api()
        {
            automation = new AutomationDB();
        }
        public async void VerifyCredential(string uname, string pass, string platform)
        {
            string url = "http://192.168.0.108:5000/" + platform + "/verify";
            IEnumerable<KeyValuePair<string, string>> query = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("email", uname),
                new KeyValuePair<string, string>("password", pass)
            };
            HttpContent q = new FormUrlEncodedContent(query);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PutAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headerrs = content.Headers;
                        //tb.Text = mycontent;
                        //we need cookies file returned here
                        //check validation here
                        //return a response respective to credentials i.e. true or false
                        //insert cookies to database
                    }
                }
            }
        }
        public async void scrapeMedia(string email, string password, string targetuser, int numofposts, string platform, string type, int CID)
        {
            try
            {
                string url = "http://127.0.0.1:5000/" + platform + "/fetch/" + type;
                //IEnumerable<KeyValuePair<string, string>> query = new List<KeyValuePair<string, string>>()
                //{
                //new KeyValuePair<string, string>("email", email),
                //new KeyValuePair<string, string>("password", password),
                //new KeyValuePair<string, string>("target_user", targetuser),
                //new KeyValuePair<string, string>("subreddit", targetuser),
                //new KeyValuePair<string, string>("hashtag", targetuser),
                //new KeyValuePair<string, string>("search", targetuser),
                //new KeyValuePair<string, string>("board", targetuser),
                //new KeyValuePair<string, string>("group_url", targetuser),
                //new KeyValuePair<string, string>("no_of_posts", Convert.ToString(numofposts))
                //};
                Dictionary dictionary = new Dictionary();
                dictionary.email = email;
                dictionary.username = email;
                dictionary.password = password;
                dictionary.target_user = targetuser;
                dictionary.subreddit = targetuser;
                dictionary.hashtag = targetuser;
                dictionary.search = targetuser;
                dictionary.board = targetuser;
                dictionary.group_url = targetuser;
                dictionary.no_of_posts = Convert.ToString(numofposts);
                var json = JsonConvert.SerializeObject(dictionary);
                var data = new StringContent(json, System.Text.Encoding.UTF32, "application/json");
                // HttpContent q = new FormUrlEncodedContent(query);
               
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(80);
                    using (HttpResponseMessage response = await Task.Run(() => client.PutAsync(url, data)))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await Task.Run(() => content.ReadAsStringAsync());
                            HttpContentHeaders headerrs = content.Headers;
                            MessageBox.Show(mycontent);
                            if (platform == "instagram")
                            {
                                scrapeIG(mycontent, CID);
                            }
                            else if (platform == "pinterest")
                            {
                                scrapePT(mycontent, CID);
                            }
                            else if (platform == "facebook")
                            {
                                scrapeFB(mycontent, CID);
                            }
                            else if (platform == "reddit")
                            {
                                scrapeRD(mycontent, CID);
                            }
                            else if (platform == "twitter")
                            {
                                scrapeTW(mycontent, CID);
                            }
                            else
                            {
                                MessageBox.Show("Still to develop!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void scrapeIG(string response, int CID)
        {
            response = JsonConvert.DeserializeObject<string>(response);
            MessageBox.Show(response);
            var data = JsonConvert.DeserializeObject<Instagram>(response); //response in quotes
            string name = data.username;
            string bio = data.bio;
            string follower = data.follower;
            string following = data.following;
            string[] imgurl;
            string[] vidurl;
            foreach (var i in data.posts)
            {
                string like = i.like;
                string comments = i.comment;
                imgurl = i.image;
                vidurl = i.video;
                string dateposted = i.date_posted;
                saveMedia(name, "Instagram", imgurl, ".jpg");
                saveMedia(name, "Instagram", vidurl, ".mp4");
                string post_id = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt");
                for (int j = 0; j < imgurl.Length; j++)
                {
                    string cmd = "INSERT into Instagram values('" + post_id + "','" + name + "','" + bio + "','" + follower + "','" + following + "','" + like + "','"+ null + "','" + null + "','" + comments + "','" + dateposted + "','" + null + "','" + imgurl[j] + "','" + null + "','" + CID + "')";
                    automation.Query(cmd, "");
                }
                for (int j = 0; j < vidurl.Length; j++)
                {
                    string cmd = "INSERT into Instagram values('" + post_id + "','" + name + "','" + bio + "','" + follower + "','" + following + "','" + like + "','" + null + "','" + null + "','" + comments + "','" + dateposted + "','" + null + "','" + null + "','" + vidurl[j] + "','" + CID + "')";
                    automation.Query(cmd, "");
                }
                int num = Convert.ToInt32(post_id);
                ++num;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt", num.ToString());
            }
            MessageBox.Show("All media saved to directory!");
        }
        public void scrapeFB(string response, int CID)
        {
            response = JsonConvert.DeserializeObject<string>(response);
            MessageBox.Show(response); //remove
            var data = JsonConvert.DeserializeObject<Facebook>(response);
            MessageBox.Show("Check 1"); //remove
            string name = data.username;
            AutomationDB automationDB = new AutomationDB();
            //string name = "Group";  //remove
            foreach (var i in data.posts)
            {
                MessageBox.Show("Staart");//remove
                string[] video = i.video;
                string post_url = i.post_url;
                string[] img = i.img;
                string like = i.like;
                string share = i.share;
                string comment = i.comment;
                //video[0] = i.video;
                //MessageBox.Show(video[0]);//remove
                saveMedia(name, "Facebook", video, ".mp4");
                saveMedia(name, "Facebook", img, ".jpg");
                MessageBox.Show("shhh");//remove
                MessageBox.Show("Check Length: " + img.Length.ToString()); //remove              
                MessageBox.Show("Check Length video: " + video.Length.ToString()); //remove              
                MessageBox.Show("Check 3");//remove
                string post_id = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt");
                for (int j = 0; j < img.Length; j++)
                {
                    MessageBox.Show("Check 7");//remove
                    string cmd = "INSERT into Facebook values('" + post_id + "','" + name + "','" + post_url + "','" + img[j] + "','" + like + "','" + share + "','" + comment + "','" + null + "','" + CID + "')";
                    automationDB.Query(cmd, "");
                }
                for (int j = 0; j < video.Length; j++)
                {
                    MessageBox.Show("Check 8");//remove
                    string cmd = "INSERT into Facebook values('" + post_id + "','" + name + "','" + post_url + "','" + null + "','" + like + "','" + share + "','" + comment + "','" + video[j] + "','" + CID + "')";
                    automationDB.Query(cmd, "");
                }
                MessageBox.Show("Check 12");//remove
                int num = Convert.ToInt32(post_id);
                ++num;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt", num.ToString());
                MessageBox.Show("end");//remove
            }
            MessageBox.Show("All media saved to directory!");

        }
        public void scrapeRD(string response, int CID)
        {
            response = JsonConvert.DeserializeObject<string>(response);
            MessageBox.Show(response);
            var data = JsonConvert.DeserializeObject<Reddit>(response);
            string name = data.username;
            //MessageBox.Show(name);
            string[] img = new string[1];
            string[] video = new string[1];
            string post_id = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt");
            foreach (var i in data.posts)
            {
                string post_url = i.post_url;
                img[0] = i.img;
               // MessageBox.Show(img[0]);
                string comment = i.comment;
                video[0] = i.video;
                string upsight = i.upsight;
                //MessageBox.Show(video[0]);//remove
                if (!String.IsNullOrEmpty(video[0]))
                {
                    //MessageBox.Show("inside if");//remove
                    saveMedia(name, "Reddit", video, ".mp4");
                }
                if (!String.IsNullOrEmpty(img[0]))
                {
                   // MessageBox.Show("inside if of img");//remove
                    saveMedia(name, "Reddit", img, ".jpg");
                }
                string cmd = "INSERT into Reddit values('" + post_id + "','" + name + "','" + img[0] + "','" + video[0] + "','" + null+"','"+null+"','"+ comment + "','" + upsight + "','" + post_url + "','" + CID + "')";
                automation.Query(cmd, "");
                int num = Convert.ToInt32(post_id);
                ++num;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt", num.ToString());
            }
            MessageBox.Show("All media saved to directory!");//remove
        }
        public void scrapeTW(string response, int CID)
        {
            response = JsonConvert.DeserializeObject<string>(response);
            MessageBox.Show(response);//remove
            var data = JsonConvert.DeserializeObject<Twitter>(response);
            string username = data.username;
            string name = data.name;
            string bio = data.bio;
            string follower = data.follower;
            string following = data.following;
            string location = data.location;
            string join_date = data.join_date;
            string[] imgurl;
            string[] video;
            foreach (var i in data.tweet)
            {
                string post_id = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt");
                //MessageBox.Show("Check 1");//remove
                string like = i.like;
                //MessageBox.Show(like);//remove
                string desc = i.desc;
                //MessageBox.Show(desc);//remove
                string retweet = i.retweet;
                string reply = i.reply;
                video = i.video;      //array
                imgurl = i.image;
                //MessageBox.Show("Check 2");//remove
                saveMedia(username, "Twitter", imgurl, ".jpg");
                saveMedia(username, "Twitter", video, ".mp4");
                for (int j = 0; j < imgurl.Length; j++)
                {
                    string cmd = "INSERT into Twitter values('" + post_id + "','" + username + "','" + name + "','" + bio + "','" + follower + "','" + following + "','" + location + "','" + join_date + "','" + null + "','" + desc + "','" + like + "','" + retweet + "','" + reply + "','" + imgurl[j] + "','" + null + "','" + CID + "')";
                    automation.Query(cmd, "");
                }
                for (int j = 0; j < video.Length; j++)
                {
                    string cmd = "INSERT into Twitter values('" + post_id + "','" + username + "','" + name + "','" + bio + "','" + follower + "','" + following + "','" + location + "','" + join_date + "','" +null +"','"+ desc + "','" + like + "','" + retweet + "','" + reply + "','" + null + "','" + video[j] + "','" + CID + "')";
                    automation.Query(cmd, "");
                }
               // MessageBox.Show("End");//remove
                int num = Convert.ToInt32(post_id);
                ++num;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt", num.ToString());
            }

            MessageBox.Show("All media saved to directory!");
        }
        public void scrapePT(string response, int CID)
        {
            response = JsonConvert.DeserializeObject<string>(response);
            var data = JsonConvert.DeserializeObject<Pinterest>(response);
            string name = data.username;
            string bio = data.bio;
            string follower = data.follower;
            string following = data.following;
            string view = data.views;
            string[] imgurl;
            string[] vidurl;
            string post_id = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt");
            foreach (var i in data.posts)
            {
                string title = i.title;
                string desc = i.desc;
                string comment = i.comment;
                int repin = i.repin;
                int pin_saved = i.pin_saved;
                string datac = i.date_created;
                imgurl = i.image;
                vidurl = i.video;
                saveMedia(name, "Pinterest", imgurl, ".jpg");
                saveMedia(name, "Pinterest", vidurl, ".mp4");
                for (int j = 0; j < imgurl.Length; j++)
                {
                    string cmd = "INSERT into Pinterest values('" + post_id + "','" + title + "','" + name + "','" + follower + "','" + following + "','" + bio + "','" + view + "','" + desc + "','" + comment + "','" + repin + "','" + pin_saved + "','" + datac + "','" + imgurl[j] + "','" + null + "','" + CID + "')";

                    automation.Query(cmd, "");
                }
                for (int j = 0; j < vidurl.Length; j++)
                {
                    string cmd = "INSERT into Pinterest values('" + post_id + "','" + title + "','" + name + "','" + follower + "','" + following + "','" + bio + "','" + view + "','" + desc + "','" + comment + "','" + repin + "','" + pin_saved + "','" + datac + "','" + null + "','" + vidurl[j] + "','" + CID + "')";

                    automation.Query(cmd, "");
                }
                int num = Convert.ToInt32(post_id);
                ++num;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\integers.txt", num.ToString());
            }
            MessageBox.Show("All media saved to directory!");
        }
        private void saveMedia(string username, string platform, string[] url, string ext)
        {
            string td = DateTime.Now.ToString("dd-MMM-yyyy");
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Media" + "\\" + platform + "\\" + username + "\\" + td + "\\";

            DirectoryInfo directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                directory.Create();
            }
            for (int i = 0; i < url.Length; i++)
            {
                string[] part1 = url[i].Split('?');
                string[] part2 = part1[0].Split('/');
                string[] name = part2[part2.Length - 1].Split('.');
                string finalpath = directory + name[0] + ext;
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new Uri(url[i]), finalpath
                        );

                }
            }

        }
        public async void postDATA(string username, string password, string platform, string folderP, string[] mediaArr, string titlee, string desc) //string uname, string pass, string platform, desc, title,
        {
            try
            {
                Postdata postdata = new Postdata();
                postdata.email = username;
                postdata.password = password;
                postdata.username = username;
                postdata.desc = new string[] { desc };
                postdata.title = new string[] { titlee };
                postdata.destination_link = new string[] { "google.com" };
                string[,] arr2 = new string[1, mediaArr.Length - 1];
                for (int i = 0; i < mediaArr.Length - 1; i++)
                {
                    arr2[0, i] = mediaArr[i];
                }
                postdata.image = arr2;
                postdata.media = arr2;
                postdata.link = new string[] { null };
                postdata.feeling = new string[] { null };
                postdata.community = new string[] { "u/" + desc };
                postdata.tag = new string[] { null };
                var json = JsonConvert.SerializeObject(postdata);
                File.WriteAllText(@"D:\ok.txt", json);
                var content = new StringContent(json, System.Text.Encoding.UTF32, "application/json");
                string feed = "feed";
                string publish = "post";
                if (platform == "Pinterest")
                {
                    feed = "pin";
                }
                else if(platform == "Facebook")
                {
                    publish = "publish";
                    feed = "user";
                }
                string url = "http://127.0.0.1:5000/" + platform.ToLower() + "/" + publish + "/" + feed;
                //string url = "http://127.0.0.1:5000/reddit/post/feed";
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
}