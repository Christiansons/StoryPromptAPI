namespace StoryPromptAPI.Models.DTOs.StoryReactions


{
    public class CreateStoryReactionsDTO

    {
        public string Reaction { get; set; }
        public int StoryId { get; set; }
        public string UserId { get; set; }
    }
}
