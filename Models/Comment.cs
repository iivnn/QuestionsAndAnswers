using QuestionsAndAnswers.Models.Interfaces;

namespace QuestionsAndAnswers.Models
{
    public class Comment : IHasTimestamps
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public User User { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public long? QuestionId { get; set; }
        public Answer Answer { get; set; } = null!;
        public long? AnswerId { get; set; }
        public List<User> UsersLike { get; set; } = null!;
        public List<User> UsersDislike { get; set; } = null!;
        public DateTime Added { get; set; } = DateTime.MinValue;
        public DateTime Deleted { get; set; } = DateTime.MinValue;
        public DateTime Modified { get; set; } = DateTime.MinValue;
    }
}
