using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsAndAnswers.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required, MaxLength(30)]
        public string Nickname { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string About { get; set; } = string.Empty;
        public string ImageLink { get; set; } = string.Empty;
        public bool Deleted { get; set; } = false;
        public List<Tag> Tags { get; set; } = [];
        public List<Question> Questions { get; set; } = [];
        public DateTime? CreatedAt { get; protected set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
