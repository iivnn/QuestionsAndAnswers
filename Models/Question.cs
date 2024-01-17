namespace QuestionsAndAnswers.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
