using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAutomationTool.MODEL
{
    public class Twitter
    {
        public string username { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public string follower { get; set; }
        public string following { get; set; }
        public string location { get; set; }
        public string join_date { get; set; }
        public Tweet[] tweet { get; set; }
    }
    public class Tweet
    {
        public string desc { get; set; }
        public string like { get; set; }
        public string retweet { get; set; }
        public string reply { get; set; }
        public string[] image { get; set; }
        public string[] video { get; set; }
    }
}
