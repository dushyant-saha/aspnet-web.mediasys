using MediaSysTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaSysTask
{
    public partial class Dashboard : System.Web.UI.Page
    {

        public string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["AuthToken"];

            if (cookie == null)
            {
                ((SiteMaster)Master).Nav_LogIn.Visible = true;
                ((SiteMaster)Master).Nav_LogOut.Visible = false;
                ((SiteMaster)Master).Nav_Register.Visible = true;
                Server.Transfer("ErrorPage.aspx");
                return;
            }

            try
            {
                var user = JwtValidator.ValidateToken(cookie.Value);
                username = user.Identity.Name;
                ((SiteMaster)Master).Nav_LogIn.Visible = false;
                ((SiteMaster)Master).Nav_LogOut.Visible = true;
                ((SiteMaster)Master).Nav_Register.Visible = false;
                // Now you can use username
                if (!IsPostBack)
                {
                    BindTasks();
                }
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            var tasks = (List<TaskItem>)Application["Tasks"];

            // CHECK IF EDIT MODE
            if (ViewState["EditTaskId"] != null)
            {
                string id = ViewState["EditTaskId"].ToString();

                var task = tasks.FirstOrDefault(t => t.Id == id);

                if (task != null)
                {
                    task.Title = txtTitle.Text;
                    task.Description = txtDescription.Text;
                    task.Status = ddlStatus.SelectedValue;
                    task.Priority = ddlPriority.SelectedValue;
                }

                ViewState["EditTaskId"] = null;
                btnAddTask.Text = "Add Task";
                //ShowAlert("Task updated!", "success");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"appendAlert('Task updated!', 'success');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "modify", $"document.getElementById('deleteTask_{task.Id}').hidden = false;", true);
                ClientScript.RegisterStartupScript(this.GetType(), "modify-1", $"document.getElementById('editTask_{task.Id}').hidden = false;", true);
            }
            else
            {
                // NORMAL ADD
                tasks.Add(new TaskItem
                {
                    Username = username,
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    Status = ddlStatus.SelectedValue,
                    Priority = ddlPriority.SelectedValue
                });
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"appendAlert('Task added!', 'success');", true);
                //ShowAlert("Task added!", "success");
            }

            Application["Tasks"] = tasks;

            BindTasks();

            ClearForm();
        }


        protected void btnDeleteHidden_Click(object sender, EventArgs e)
        {
            string id = hfDeleteTaskId.Value;
            var tasks = (List<TaskItem>)Application["Tasks"];

            Application.Lock();

            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }

            Application["Tasks"] = tasks;

            Application.UnLock();

            BindTasks();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"appendAlert('Task deleted!', 'info');", true);
        }

        protected void btnEditHidden_Click(object sender, EventArgs e)
        {
            string id = hfEditTaskId.Value;

            var tasks = (List<TaskItem>)Application["Tasks"];

            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                txtTitle.Text = task.Title;
                txtDescription.Text = task.Description;
                ddlStatus.SelectedValue = task.Status;
                ddlPriority.SelectedValue = task.Priority;

                // Store editing ID
                ViewState["EditTaskId"] = task.Id;
                btnAddTask.Text = "Update Task";
                ClientScript.RegisterStartupScript(this.GetType(), "modify", $"document.getElementById('deleteTask_{task.Id}').hidden = true;", true);
                ClientScript.RegisterStartupScript(this.GetType(), "modify-1", $"document.getElementById('editTask_{task.Id}').hidden = true;", true);
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var tasks = (List<TaskItem>)Application["Tasks"];
            var filtered = tasks.Where(t => t.Username == username && t.Title.ToLower().Contains(txtSearch.Text.ToLower())
            && (ddlStatusFilter.SelectedValue == "All" || t.Status == ddlStatusFilter.SelectedValue) 
            && (ddlPriorityFilter.SelectedValue == "All" || t.Priority == ddlPriorityFilter.SelectedValue)).ToList();

            RenderTasks(filtered);
        }
        private void BindTasks()
        {
            var tasks = (List<TaskItem>)Application["Tasks"];
            string currentUser = username;

            var userTasks = tasks
                .Where(t => t.Username == currentUser)
                .ToList();

            RenderTasks(userTasks);
        }
        private void RenderTasks(List<TaskItem> userTasks)
        {
            string html = "<table class='table'>";

            foreach (var t in userTasks)
            {
                html += $@"
        <tr>
            <td>{t.Title}</td>
            <td>{t.Status}</td>
            <td>{t.Priority}</td>
            <td class='text-end'>
                <button id=""editTask_{t.Id}"" class=""btn btn-info"" onclick=""editTask('{t.Id}')"">Edit</button>
                <button id=""deleteTask_{t.Id}"" class=""btn btn-danger"" onclick=""deleteTask('{t.Id}')"">Delete</button>
            </td>
        </tr>";
            }

            html += "</table>";

            litTasks.Text = html;
        }
        private void ClearForm()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            ddlStatus.SelectedIndex = 0;
            ddlPriority.SelectedIndex = 0;
        }
        //public void ShowAlert(string msg, string type)
        //{
        //    ScriptManager.RegisterStartupScript(
        //        this,
        //        this.GetType(),
        //        Guid.NewGuid().ToString(),
        //        $"appendAlert('{msg}', '{type}');",
        //        true
        //    );
        //}
    }
}