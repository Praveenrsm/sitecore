using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitecoreassignment1.Models
{
    public class BannerViewModel
    {
        public Item Item { get; set; }
        public string Title { get; set; }
        public string sub_title { get; set; }
        public string Description { get; set; }
        public string imgTag;
        public string call_to_action { get; set; }
    }
}