using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models.Entities
{
    public class PromptReactions
    {
        [Key]
        public int PromptReactionsId { get; set; }
        public string PromptReaction { get; set; }

        [ForeignKey("Prompt")]
        public int PromptIdFK { get; set; }
        public virtual Prompt Prompt { get; set; }

        [ForeignKey("User")]
        public string UserIdFK { get; set; }
        public virtual User User { get; set; }
    }
}
