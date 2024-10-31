namespace StoryPromptAPI.Models.DTOs.StoryReactions
{
    public class StoryReactionsDTO

    {
        public int Id { get; set; }
        public string Reaction { get; set; }  // e.g., "Like" or "Dislike"
        public int StoryId { get; set; }
        public string UserId { get; set; }
    }
}
