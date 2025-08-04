using System.ComponentModel.DataAnnotations;

namespace HandsOnLab.ASPCoreClient.Models
{
    public class LoginViewModel
    {
        //email
        public string Email { get; set; }

        //password
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
