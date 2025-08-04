using HandsOnLab.WebFormClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace HandsOnLab.WebFormClient.Servives
{
    public class AccountServices
    {
        private HttpClient httpClient;
        private string token;
        public AccountServices()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7095");


        }

        //login
        public async Task<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            try
            {
                // Serialize the login model to JSON
                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(loginViewModel);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/Usman/login", content);
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Deserialize the response to UserViewModel
                    var userViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(responseContent);
                    return userViewModel;
                }
                else
                {
                    throw new Exception("Login failed. Please check your credentials.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login: {ex.Message}");
            }
        }
    }
}