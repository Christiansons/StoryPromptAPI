namespace StoryPromptAPI.Models.DTOs.PromptReactions
{
    public class PromptReactionsDTO

    {
        public int Id { get; set; }
        public string Reaction { get; set; }  // Assuming values like "Like" or "Dislike"
        public int PromptId { get; set; }
        public string UserId { get; set; }
    }
}
