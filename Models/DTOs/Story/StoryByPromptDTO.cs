using StoryPromptAPI.Models.DTOs.Prompt;
using StoryPromptAPI.Models.DTOs.User;

namespace StoryPromptAPI.Models.DTOs.Story
{
    public class StoryByPromptDTO
    {
        public int Id { get; set; }
        public string StoryContent { get; set; }
        public DateTime StoryDateCreated { get; set; }
        public UserDTO user { get; set; }
        public int ReactionCount { get; set; }
    }
}
