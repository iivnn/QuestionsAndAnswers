using QuestionsAndAnswers.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Tag : IHasTimestamps
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DescriptionEN { get; set; } = string.Empty;
        public string DescriptionPT { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string InnerColor { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = [];
        public List<User> Users { get; set; } = [];
        public DateTime Added { get; set; } = DateTime.MinValue;
        public DateTime Deleted { get; set; } = DateTime.MinValue;
        public DateTime Modified { get; set; } = DateTime.MinValue;
    }
}
