using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAutomationTool.MODEL
{
    public class Instagram
    {
        public string username { get; set; }
        public string bio { get; set; }
        public string follower { get; set; }
        public string following { get; set; }
        public PostI[] posts { get; set; }
    }
    public class PostI
    {
        public string like { get; set; }
        public string comment { get; set; }
        public string[] image { get; set; }
        public string[] video { get; set; }
        public string date_posted { get; set; }
        //public int post_id { get; set; }
    }
}
