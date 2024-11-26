namespace StoryPromptAPI.Models.DTOs.Prompt

{
    public class PromptDTO
    {
        public int Id { get; set; }
        public string PromptContent { get; set; }
        public DateTime PromptDateCreated { get; set; }

        public string UserId { get; set; }
    }
}
