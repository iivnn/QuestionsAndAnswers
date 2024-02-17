using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string DescriptionEN { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string DescriptionPT { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string Color { get; set; } = string.Empty;
        public List<Question>? Questions { get; set; } = [];
        public DateTime? CreatedAt { get; protected set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
