using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class Question
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(maximumLength: 10000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public Tag Tag{ get; set; } = default!;
        [Required]
        public User User { get; set; } = default!;
        public DateTime? CreatedAt { get; protected set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
