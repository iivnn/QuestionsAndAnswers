using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class User : IdentityUser
    {
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
