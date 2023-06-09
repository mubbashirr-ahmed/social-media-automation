using System.Collections.Generic;

namespace SocialMediaAutomationTool.MODEL
{
    public class Postdata
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string[] desc { get; set; }
        public string[] title { get; set; }
        public string[] destination_link { get; set; }
        public string[] community { get; set; }
        public string[] link { get; set; }
        public string[] feeling { get; set; }
        public string[,] image { get; set; }
        public string[,] media { get; set; }
        public string[] tag { get; set; }
       // public List<Media> data { get; set; } = new List<Media>();
    }
   
}
