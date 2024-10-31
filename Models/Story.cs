using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryPromptAPI.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string StoryContent { get; set; }

        public DateTime StoryDateCreated { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }


        public int PromptId { get; set; }

        public Prompt Prompt { get; set; }

        public ICollection<StoryReactions> StoriesReactions { get; set; }

    }
}
