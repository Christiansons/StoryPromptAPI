using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models.Entities
{
    public class Prompt
    {
        [Key]
        public int PromptId { get; set; }
        public string PromptContent { get; set; } = string.Empty;
        public DateTime PromptCreatedDate { get; set; }

        [ForeignKey("User")]
        public string UserIdFK { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<PromptReactions> PromptReactions { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
