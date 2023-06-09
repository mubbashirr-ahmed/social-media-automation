using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAutomationTool.MODEL
{
    public class Pinterest
    {
        public string username { get; set; }
        public string follower { get; set; }
        public string following { get; set; }
        public string bio { get; set; }
        public string views { get; set; }
        public PostP[] posts { get; set; }
    }
    public class PostP
    {
        public string title { get; set; }
        public string desc { get; set; }
        public string comment { get; set; }
        public int repin { get; set; }
        public int pin_saved { get; set; }
        public string date_created { get; set; }
        public string[] image { get; set; }
        public string[] video { get; set; }
        public string search_tag { get; set; }

    }
}
