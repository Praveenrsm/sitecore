using Sitecore.Data.Items;
using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using sitecoreassignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using static Sitecore.Shell.UserOptions.HtmlEditor;
using Sitecore.Shell.Framework.Commands.Carousel;
using Sitecore.Shell.Framework.Commands.ContentEditor;

namespace sitecoreassignment1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var model = new BannerViewModel()
            {
                Item = RenderingContext.Current?.Rendering.Item
            };
            model.Title = model.Item.Fields["{D77B1085-EB0F-490F-9FBB-7DA543FF7436}"].ToString();
            model.sub_title = model.Item.Fields["{D498BCBB-FE18-4297-8F4A-E0E7ADE64D45}"].ToString();

            model.Description = model.Item.Fields["{EC7E892D-CA24-4D78-8D23-82C1C5AC91FA}"].ToString();

            ImageField Image = model.Item.Fields["{C6227B35-AC3A-4256-BBDA-E0DC512DF7A1}"];

            MediaItem image = new MediaItem(Image.MediaItem);
            string src = StringUtil.EnsurePrefix('/',
            Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
            model.imgTag = String.Format(@"<img src=""{0}"" alt=""{1}"" />", src, image.Alt);
            LinkField call_to_action1 = model.Item.Fields["{C9319680-090E-4F48-9FC2-171A96A806D0}"];
            model.call_to_action = String.Empty;
            switch (call_to_action1.LinkType)
            {
                case "internal":
                case "external":
                case "mailto":
                case "anchor":
                case "javascript":
                    model.call_to_action = call_to_action1.Url;
                    break;
                case "media":
                    Sitecore.Data.Items.MediaItem media = new Sitecore.Data.Items.MediaItem(call_to_action1.TargetItem);
                    model.call_to_action = Sitecore.StringUtil.EnsurePrefix('/',
                    Sitecore.Resources.Media.MediaManager.GetMediaUrl(media));
                    break;
                case "":
                    break;
                default:
                    //string message = String.Format("{0} : Unknown link type {1} in {2}", this.GetType(), call_to_action1.LinkType, model.Item.Paths.FullPath); Sitecore.Diagnostics.Log.Error(message, this);
                    if (call_to_action1 == null)
                    {
                        // Field does not exist
                    }
                    else if (call_to_action1.TargetItem == null)
                    {
                        // No item selected
                    }
                    else
                    {
                        model.call_to_action = call_to_action1.Url;
                        // Process referenced item
                    }
                    break;
            }
            //model.Item.Editing.BeginEdit();
            //call_to_action1.Clear();

            //call_to_action1.LinkType = "media";

            //call_to_action1.Url = model.Item.Paths.MediaPath;

            //call_to_action1.TargetID = model.Item.ID;

            //model.Item.Editing.EndEdit();
            return View(model);
        }
    }
}