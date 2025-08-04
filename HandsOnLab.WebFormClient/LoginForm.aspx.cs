using HandsOnLab.WebFormClient.Models;
using HandsOnLab.WebFormClient.Servives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandsOnLab.WebFormClient
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private AccountServices accountServices = new AccountServices();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await accountServices.Login(new LoginViewModel
                {
                    Email = txtUsername.Text,
                    Password = txtPassword.Text
                });
                if (result != null)
                {
                    Session["username"] = new UserViewModel
                    {
                        Email = result.Email,
                        Token = result.Token
                    };

                    ltMessage.Text = $"<span class='alert alert-success'>Login successful! Welcome {result.Email} - {result.Token}</span>";

                    Response.Redirect("Default.aspx?CarId=1", false);
                    //Context.ApplicationInstance.CompleteRequest();

                    //UserViewModel user = (UserViewModel)Session["username"];

                }
                else
                {
                    ltMessage.Text = "<span class='alert alert-danger'>Login failed. Please check your credentials.</span>";
                }
            }
            catch (Exception ex)
            {
                ltMessage.Text = $"<span class='alert alert-danger'>Error during login: {ex.Message}</span>";
            }
        }
    }
}