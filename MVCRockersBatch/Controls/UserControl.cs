using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRockersBatch.Controls
{
    public static class UserControl
    {
        public static IHtmlString MyLabel(string content)
        {
            string htmlstring = String.Format("<label>{0}</label>", content);
            return new HtmlString(htmlstring);
        }

        public static IHtmlString createUrControl(this HtmlHelper helper, string content)
        {
            string htmlstring = "<input type=" + content + ">";
            return new HtmlString(htmlstring);
        }


    }
}