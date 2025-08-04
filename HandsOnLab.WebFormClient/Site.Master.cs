using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandsOnLab.WebFormClient
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                hlLogout.Text = "Login";
                hlLogout.NavigateUrl = "LoginForm.aspx?ReturnUrl=Default.aspx";
            }
            else
            {
                hlLogout.Text = "Logout";
                hlLogout.NavigateUrl = "Logout.aspx";
            }
        }
    }
}