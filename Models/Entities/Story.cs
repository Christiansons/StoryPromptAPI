using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models.Entities
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        public string StoryContent { get; set; } = string.Empty;
        public DateTime StoryCreatedDate { get; set; }

        [ForeignKey("User")]
        public string UserIdFK { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Prompt")]
        public int PromptIdFK { get; set; }
        public virtual Prompt Prompt { get; set; }

        public virtual ICollection<StoryReactions> StoryReactions { get; set; }
    }
}
