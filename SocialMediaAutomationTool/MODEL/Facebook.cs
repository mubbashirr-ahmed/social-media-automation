using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAutomationTool.MODEL
{
    public class Facebook
    {
        public string username { get; set; }
        public PostsF[] posts { get; set; }
    }
    public class PostsF
    {
        public string post_url { get; set; }
        public string[] img { get; set; }
        public string like { get; set; }
        public string share { get; set; }
        public string comment { get; set; }
        public string[] video { get; set; }
    }
}
