namespace QuestionsAndAnswers.Models.ViewModels
{
    public record ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
