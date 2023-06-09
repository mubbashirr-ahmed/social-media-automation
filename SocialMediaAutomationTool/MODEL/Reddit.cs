    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAutomationTool.MODEL
{
    public class Reddit
    {
        public string username { get; set; }
        public PostsR[] posts { get; set; }
    }
    public class PostsR
    {
        public string img { get; set; }
        public string video { get; set; }
        public string comment { get; set; }
        public string upsight { get; set; }
        public string post_url { get; set; }
    }
}
