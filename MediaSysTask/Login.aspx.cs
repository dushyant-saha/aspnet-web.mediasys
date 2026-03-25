using MediaSysTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSysTask
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMaster)Master).Nav_LogIn.Visible = true;
            ((SiteMaster)Master).Nav_LogOut.Visible = false;
            ((SiteMaster)Master).Nav_Register.Visible = true;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string email = exampleInputEmail.Text;
            string password = exampleInputPassword.Text;
            var userList = (List<User>)Application["Users"];

            var user = userList.Find(u => u.Email == email);

            if (user != null && user.Password == password)
            {
                string token = JwtHelper.GenerateToken(user.Username);

                // Store token in cookie
                HttpCookie cookie = new HttpCookie("AuthToken", token);
                cookie.HttpOnly = true;
                cookie.Secure = true; // use HTTPS
                Response.Cookies.Add(cookie);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"appendAlert('Valid {token}!', 'success');", true);

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),"alert","appendAlert('Invalid Credentials!', 'danger');",true);
            }
        }
    }
}