using QuestionsAndAnswers.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Question : IHasTimestamps
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Tag Tag{ get; set; } = null!;
        public int TagId { get; set; }
        public User User { get; set; } = null!;
        public List<User> UsersLike { get; set; } = null!;
        public List<User> UsersDislike { get; set; } = null!;
        public List<Answer> Answers { get; set; } = [];
        public List<Comment> Comments { get; set; } = [];
        public DateTime Added { get; set; } = DateTime.MinValue;
        public DateTime Deleted { get; set; } = DateTime.MinValue;
        public DateTime Modified { get; set; } = DateTime.MinValue;
    }
}
