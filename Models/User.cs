using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace QuestionsAndAnswers.Models
{
    public class User : IdentityUser
    {
        [MaxLength(1000)]
        public string? About { get; set; } = string.Empty;
        public string? ImageName { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = [];
        public List<Question> Questions { get; set; } = [];
        public DateTime? CreatedAt { get; protected set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
