<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MediaSysTask.Login" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <div class="mb-3">
                <label for="<%= exampleInputEmail.ClientID %>" class="form-label">Email address</label>
                <asp:TextBox ID="exampleInputEmail" runat="server" type="email" class="form-control"></asp:TextBox>
                
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div class="mb-3">
                <label for="<%= exampleInputPassword.ClientID %>" class="form-label">Password</label>
                <asp:TextBox ID="exampleInputPassword" type="password" runat="server" class="form-control"></asp:TextBox>
            </div>
            
            <asp:Button ID="Submit" runat="server" Text="Submit" class="btn btn-primary" OnClick="Submit_Click" />
            <div id="liveAlertPlaceholder" class="mt-3 text-break"></div>
        </div>
    </main>
    <script>
        const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
        const appendAlert = (message, type) => {
            const wrapper = document.createElement('div')
            wrapper.innerHTML = [
                `<div class="alert alert-${type} alert-dismissible" role="alert">`,
                `   <div>${message}</div>`,
                '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
                '</div>'
            ].join('')

            alertPlaceholder.append(wrapper)
        }
    </script>
</asp:Content>
