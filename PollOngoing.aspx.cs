using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleMobilePoll
{
    public partial class PollOngoing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // url 직접 접근 차단
            //if (Request.Url.OriginalString.Contains("PollOngoing.aspx") == true)
            //{
            //    Response.Redirect("Default.aspx", true);
            //}
        }
    }
}