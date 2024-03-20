using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models.ViewModels
{
    public class SignUpViewModel
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public IFormFile? Image { get; set; } = default;
        [MinLength(3), MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string About { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = [];     
    }
}
