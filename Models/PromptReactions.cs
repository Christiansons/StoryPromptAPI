using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models
{
    public class PromptReactions
    {
        public int Id { get; set; }
        public string Reaction { get; set; }
        public int PromptId { get; set; }

        public Prompt Prompt { get; set; }

        public string? UserId { get; set; }

        public User User { get; set; }

    }
}
