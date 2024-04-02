namespace QuestionsAndAnswers.Models
{
    public class TagUser
    {
        public long Id { get; set; }
        public int FollowedTagsId { get; set; }
        public string UsersId { get; set; } = string.Empty;
    }
}
