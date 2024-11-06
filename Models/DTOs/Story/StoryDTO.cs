namespace StoryPromptAPI.Models.DTOs.Story
{
    public class StoryDTO
    {
        public int Id { get; set; }
        public string StoryContent { get; set; }
        public DateTime StoryDateCreated { get; set; }
        public int PromptId { get; set; }
        public string UserId { get; set; }

    }
}
