using System.ComponentModel.DataAnnotations;

namespace StoryPromptAPI.Models.Entitites
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string ProfilePictureUrl { get; set; } 
        public string ProfileDescription { get; set; } = string.Empty;
        public DateTime ProfileCreatedDate { get; set; }
    }
}
