using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models.Entities
{
    public class User : IdentityUser
    {
        [ForeignKey("Profile")]
        public int ProfileIdFK { get; set; }
        public virtual Profile Profile { get; set; }

        
        public virtual ICollection<StoryReactions> StoryReactions { get; set; }
        public virtual ICollection<PromptReactions> PromptReactions { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<Prompt> Prompts { get; set; }
    }
}
