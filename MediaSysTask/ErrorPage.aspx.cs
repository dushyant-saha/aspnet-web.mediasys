using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSysTask
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMaster)Master).Nav_LogIn.Visible = true;
            ((SiteMaster)Master).Nav_LogOut.Visible = false;
            ((SiteMaster)Master).Nav_Register.Visible = true;
        }
    }
}