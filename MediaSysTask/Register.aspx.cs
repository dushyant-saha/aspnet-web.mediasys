using MediaSysTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSysTask
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMaster)Master).Nav_LogIn.Visible = true;
            ((SiteMaster)Master).Nav_LogOut.Visible = false;
            ((SiteMaster)Master).Nav_Register.Visible = true;
        }

        protected void Register_Click(object sender, EventArgs e)
        {

            var users = (List<User>)Application["Users"];

            string username = TextBox_Username.Text;
            string email = TextBox_Email.Text;
            string password = TextBox_Password.Text;

            var sb = new StringBuilder();

            if (users.Any(u => u.Username == username))
            {
                sb.AppendLine("Username already exists");
                return;
            }
            if (users.Any(u => u.Email == username))
            {
                sb.AppendLine("Email already in use");
                return;
            }

            users.Add(new User
            {
                Id = users.Count + 1,
                Username = username,
                Email = email,
                Password = password,
                Role = UserRole.Regular
            });

            Application["Users"] = users;

            //lblMessage.Text = "User registered successfully!";

        }
    }
}