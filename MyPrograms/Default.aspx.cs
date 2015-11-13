using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPrograms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for mobile device and redirect if needed
            if (Request.Browser["IsMobile"] == "True")
            {
                Response.Redirect("~/Mobile/Default.aspx");
            }
        }
    }
}