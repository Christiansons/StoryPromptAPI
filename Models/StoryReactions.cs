using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models
{
    public class StoryReactions
    {
        public int Id { get; set; }
        public string Reaction { get; set; }

        public int StoryId { get; set; }


        public Story Story { get; set; }


        public string? UserId { get; set; }


        public User User { get; set; }
    }
}
