using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models
{
    public class Prompt
    {
        public int Id { get; set; }

        public string PromptContent { get; set; }

        public DateTime PromptDateCreated { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Story> Stories { get; set; }

        public ICollection<PromptReactions> PromptsReactions { get; set; }

    }
}
