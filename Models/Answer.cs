using QuestionsAndAnswers.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Answer : IHasTimestamps
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public long QuestionId { get; set; }
        public List<Comment> Comments { get; set; } = [];
        public DateTime Added { get; set; } = DateTime.MinValue;
        public DateTime Deleted { get; set; } = DateTime.MinValue;
        public DateTime Modified { get; set; } = DateTime.MinValue;
    }
}
