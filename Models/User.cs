using Microsoft.AspNetCore.Identity;
using QuestionsAndAnswers.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace QuestionsAndAnswers.Models
{
    public class User : IdentityUser, IHasTimestamps
    {
        public string About { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public List<Tag> FollowedTags { get; set; } = [];
        public List<Question> Questions { get; set; } = [];
        public DateTime Added { get; set; } = DateTime.MinValue;
        public DateTime Deleted { get; set; } = DateTime.MinValue;
        public DateTime Modified { get; set; } = DateTime.MinValue;
    }
}
