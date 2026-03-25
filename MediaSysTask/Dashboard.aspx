<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MediaSysTask.Dashboard" %>

<%@ Import Namespace="MediaSysTask" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2 class="mt-2">Welcome <%= this.username %></h2>

        <div class="container mt-4">
            <div id="appendAlert"></div>

            <div class="card mb-4 shadow-sm">
                <div class="card-header bg-primary text-white">
                    Add Task
       
                </div>
                <div class="card-body">

                    <div class="row g-3">

                        <div class="col-md-4">
                            <asp:TextBox ID="txtTitle" runat="server"
                                CssClass="form-control"
                                Placeholder="Title" />
                        </div>

                        <div class="col-md-4">
                            <asp:TextBox ID="txtDescription" runat="server"
                                CssClass="form-control"
                                Placeholder="Description" />
                        </div>

                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlStatus" runat="server"
                                CssClass="form-select">
                                <asp:ListItem Text="Pending" Value="Pending" />
                                <asp:ListItem Text="Completed" Value="Completed" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlPriority" runat="server"
                                CssClass="form-select">
                                <asp:ListItem Text="Low" Value="Low" />
                                <asp:ListItem Text="Medium" Value="Medium" />
                                <asp:ListItem Text="High" Value="High" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-12">
                            <asp:Button ID="btnAddTask" runat="server"
                                Text="Add Task"
                                CssClass="btn btn-success"
                                OnClick="btnAddTask_Click" />
                        </div>

                    </div>

                </div>
            </div>

            <!-- 🔍 SEARCH + FILTER -->
            <div class="card mb-4 shadow-sm">
                <div class="card-header">
                    Search & Filter
       
                </div>

                <div class="card-body">
                    <div class="row g-3">

                        <div class="col-md-4">
                            <asp:TextBox ID="txtSearch" runat="server"
                                CssClass="form-control"
                                Placeholder="Search by title" />
                        </div>

                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlStatusFilter" runat="server"
                                CssClass="form-select">
                                <asp:ListItem Text="All Status" Value="All" />
                                <asp:ListItem Text="Pending" Value="Pending" />
                                <asp:ListItem Text="Completed" Value="Completed" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPriorityFilter" runat="server"
                                CssClass="form-select">
                                <asp:ListItem Text="All Priority" Value="All" />
                                <asp:ListItem Text="Low" Value="Low" />
                                <asp:ListItem Text="Medium" Value="Medium" />
                                <asp:ListItem Text="High" Value="High" />
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <asp:Button ID="btnFilter" runat="server"
                                Text="Apply"
                                CssClass="btn btn-primary w-100"
                                OnClick="btnFilter_Click" />
                        </div>

                    </div>
                </div>
            </div>

            <!-- 📋 TASK LIST -->
            <div class="card shadow-sm">
                <div class="card-header">
                    Your Tasks
       
                </div>

                <div class="card-body">

                    <!-- Rendered from backend -->
                    <asp:Literal ID="litTasks" runat="server"></asp:Literal>

                </div>
            </div>
            <asp:HiddenField ID="hfEditTaskId" runat="server" />
            <asp:Button
                ID="btnEditHidden"
                runat="server"
                OnClick="btnEditHidden_Click"
                Style="display: none;" />

            <asp:HiddenField ID="hfDeleteTaskId" runat="server" />
            <asp:Button 
                ID="btnDeleteHidden" 
                runat="server"
                OnClick="btnDeleteHidden_Click"
                Style="display: none;" />
        </div>
    </main>
    <script>
        function editTask(id) {
            debugger;
            document.getElementById('<%= hfEditTaskId.ClientID %>').value = id;
            __doPostBack('<%= btnEditHidden.UniqueID %>', '');
        }
        function deleteTask(id) {
            debugger;
            document.getElementById('<%= hfDeleteTaskId.ClientID %>').value = id;
            __doPostBack('<%= btnDeleteHidden.UniqueID %>', '');
        }
    </script>
</asp:Content>


