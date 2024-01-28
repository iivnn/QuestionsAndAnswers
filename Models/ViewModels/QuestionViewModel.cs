namespace QuestionsAndAnswers.Models.ViewModels
{
    public record QuestionViewModel
    {
        public List<Question> Questions { get; set; } = [];
    }
}
