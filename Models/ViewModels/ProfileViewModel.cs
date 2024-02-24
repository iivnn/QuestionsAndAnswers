using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string Email { get; set; } = string.Empty;
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public IFormFile? Image { get; set; } = default;
        public string? ImageName { get; set; } = string.Empty;        
        public string UserName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? About { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public List<TagProfileViewModel> Tags { get; set; } = [];
        public List<Question> Questions { get; set; } = [];
    }

    public class TagProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string InnerColor { get; set; } = string.Empty;
        public bool Checked { get; set; }
    }
}
