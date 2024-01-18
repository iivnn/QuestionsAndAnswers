using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Question
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 6000)]
        public string Description { get; set; } = string.Empty;

        public DateTime InsertedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
