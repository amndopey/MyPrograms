using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myData;

namespace MyPrograms.Members
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name.ToLower() == "james")
            {
                Button btn = new Button();
                btn.ID = "Admin_Button";
                btn.Text = ("Admin page");
                btn.Click += Admin_button_Click;
                btn.Width = Unit.Pixel(150);
                Admin_Placeholder.Controls.Add(btn);
            }
        }

        protected void Admin_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Members/Admin.aspx");
            //Response.Redirect("/myData/dbView.aspx");
        }


    }
}