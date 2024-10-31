using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }

        public ICollection<Story> Stories { get; set; }

        public ICollection<PromptReactions> PromptsReactions { get; set; }


        public ICollection<StoryReactions> StoriesReactions { get; set; }

    }
}
