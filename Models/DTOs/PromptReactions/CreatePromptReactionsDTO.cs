namespace StoryPromptAPI.Models.DTOs.PromptReactions


{
    public class CreatePromptReactionsDTO
    {
        public string reaction { get; set; }
        public int promptId { get; set; }
        public string userId { get; set; }
    }
}
