namespace QuestionsAndAnswers.Models.ViewModels
{
    public record QuestionViewModel
    {
        public List<Question> Questions { get; set; } = [];
        public string TitleSearchString { get; set; } = string.Empty;
    }
}
