using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public bool Remember { get; set; }
    }
}
