namespace QuestionsAndAnswers.Models.ViewModels
{
    public record QuestionViewModel
    {
        public List<Question> Questions { get; set; } = [];
        public List<Tag> Tags { get; set; } = [];
        public Tag? TagInfo { get; set; } = default;
        public string TotalResults { get; set; } = string.Empty;
    }
}
