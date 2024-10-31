namespace StoryPromptAPI.Models.DTOs.Story

{
    public class CreateStoryDTO
    {
        public string StoryContent { get; set; }
        public int PromptId { get; set; }
        public string UserId { get; set; }

    }
}
