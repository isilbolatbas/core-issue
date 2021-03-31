using System.ComponentModel.DataAnnotations;

namespace core_issue.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]  
        public string username { get; set; }  
  
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string email { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string password { get; set; }  
    }
}