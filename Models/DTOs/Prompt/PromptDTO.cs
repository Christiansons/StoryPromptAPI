using StoryPromptAPI.Models.DTOs.User;

using StoryPromptAPI.Models.DTOs.PromptReactions;
using StoryPromptAPI.Models.DTOs.User;

namespace StoryPromptAPI.Models.DTOs.Prompt

{
    public class PromptDTO
    {
        public int Id { get; set; }
        public string PromptContent { get; set; }
        public DateTime PromptDateCreated { get; set; }


        public string? UserId { get; set; } 

        public UserDTO user { get; set; }
        public int ReactionCount { get; set; }
        public int StoryCount   { get; set; }

    }
}
