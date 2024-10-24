using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models.Entitites
{
    public class StoryReactions
    {
        [Key]
        public int StoryReactionsId { get; set; }
        public string StoryReaction { get; set; }

        [ForeignKey("Story")]
        public int StoryIdFK { get; set; }
        public virtual Story Story { get; set; }

        [ForeignKey("User")]
        public string UserIdFK { get; set; }
        public virtual User User { get; set; }
    }
}
