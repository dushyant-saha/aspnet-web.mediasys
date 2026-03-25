using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSysTask
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        public Button Nav_LogIn
        {
            get {
                return Button_LogIn;
            }
        }
        public Button Nav_LogOut
        {
            get
            {
                return Button_LogOut;
            }
        } 
        public Button Nav_Register
        {
            get
            {
                return Button_Register;
            }
        } 


        protected void Button_LogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button_LogOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["AuthToken"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Value = "";

            Response.Cookies.Add(cookie);
            Response.Redirect("Login.aspx");
        }

        protected void Button_Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }


        void ButtonVisibility()
        {
            
            Button_LogOut.Visible = (Page is Login) || (Page is ErrorPage) ? false : true;
            Button_LogIn.Visible = !(Page is Login) ? false : true;
            Button_Register.Visible = (Page is Login) || (Page is Register) ? true : false;
        }
    }
}