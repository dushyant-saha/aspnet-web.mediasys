<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MediaSysTask.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <div class="mb-3">
                <label for="<%= TextBox_Username.ClientID %>" class="form-label">Username</label>
                <asp:TextBox ID="TextBox_Username" runat="server" type="text" class="form-control"></asp:TextBox>
                <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
            </div>
            <div class="mb-3">
                <label for="<%= TextBox_Email.ClientID %>" class="form-label">Email address</label>
                <asp:TextBox ID="TextBox_Email" runat="server" type="email" class="form-control"></asp:TextBox>
                <%--<input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">--%>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div class="mb-3">
                <label for="<%= TextBox_Password.ClientID %>" class="form-label">Password</label>
                <%--<input type="password" class="form-control" id="exampleInputPassword1">--%>
                <asp:TextBox ID="TextBox_Password" type="password" runat="server" class="form-control"></asp:TextBox>
            </div>

            <asp:Button ID="Button_Register" runat="server" Text="Register" class="btn btn-primary" OnClick="Register_Click" OnClientClick="return fieldValidate();" />
            <div id="liveAlertPlaceholder" class="mt-3"></div>

        </div>
    </main>
    <script>
        function fieldValidate() {

            debugger;
            let userField = document.getElementById("<%= TextBox_Username.ClientID %>");
            let emailField = document.getElementById("<%= TextBox_Email.ClientID %>");
            let passwordField = document.getElementById("<%= TextBox_Password.ClientID %>");
            let errors = "<ul class=`mb-0`>";
            let usernameFlag = false;
            let emailFlag = false;
            let passwordFlag = false;
            if (userField.value == null || userField.value == '') {
                errors += "<li>Username is mandatory</li>\n";
                usernameFlag = true;
            }
            if (emailField.value == null || emailField.value == '') {
                errors += "<li>Email is mandatory</li>";
                emailFlag = true;
            }
            if (passwordField.value == null || passwordField.value == '') {
                errors += "<li>Password is mandatory</li>";
                passwordFlag = true;
            }
            if (usernameFlag || emailFlag || passwordFlag) {
                errors += "</ul>";
                appendAlert(errors, 'danger');

                return false;
            }
            else {
                appendAlert(`${userField} Registered as User`, 'success');
                return true;
            }
        }
    </script>
</asp:Content>
