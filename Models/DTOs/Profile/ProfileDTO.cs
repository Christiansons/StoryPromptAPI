namespace StoryPromptAPI.Models.DTOs.Profile

{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateOnly ProfileCreated { get; set; }
        public string UserId { get; set; }
    }
}
