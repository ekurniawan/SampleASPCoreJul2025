<%@ Page Title="Login Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="LoginForm.aspx.cs" Inherits="HandsOnLab.WebFormClient.LoginForm" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h3 id="aspnetTitle">Login Form</h3>
        </section>
        <br />
        <div class="row">
            <asp:Literal ID="ltMessage" runat="server" /><br />
            <div class="col-md-4">
                <div class="mb-3 mt-3">
                    <label for="Username" class="form-label">Username :</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="Password" class="form-label">Password :</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-sm" OnClick="btnLogin_Click" />
            </div>
        </div>
    </main>
</asp:Content>
