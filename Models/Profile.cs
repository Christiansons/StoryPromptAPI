using System.ComponentModel.DataAnnotations;

namespace StoryPromptAPI.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
        public DateOnly ProfileCreated { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
