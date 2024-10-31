namespace StoryPromptAPI.Models.DTOs.PromptReactions


{
    public class CreatePromptReactionsDTO

    {
        public string Reaction { get; set; }
        public int PromptId { get; set; }
        public string UserId { get; set; }
    }
}
