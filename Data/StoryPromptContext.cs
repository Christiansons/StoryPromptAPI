using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI.Data
{
    public class StoryPromptContext : IdentityDbContext<User>
    {
        public StoryPromptContext(DbContextOptions<StoryPromptContext> options) : base (options) { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<User> AllUsers { get; set; }
        public DbSet<PromptReactions> PromptsReactions { get; set; }
        public DbSet<StoryReactions> StoriesReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //----------------- Disable deletebehavior for promptreactions ----------------
            modelBuilder.Entity<PromptReactions>()
                .HasOne(pr => pr.Prompt)  // Assuming a navigation property to Prompts
                .WithMany(p => p.PromptReactions)  // Assuming Prompts has a collection of PromptsReactions
                .HasForeignKey(pr => pr.PromptIdFK)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete

            // Configuring the relationship between PromptsReactions and another entity, e.g., User or Reaction
            modelBuilder.Entity<PromptReactions>()
                .HasOne(pr => pr.User)  // Assuming a navigation property to User or another entity
                .WithMany(u => u.PromptReactions)  // Assuming User or Reaction has a collection of PromptsReactions
                .HasForeignKey(pr => pr.UserIdFK)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete



            //--------------- Disable deletebehavior for storyreactions -----------------
            modelBuilder.Entity<StoryReactions>()
                .HasOne(pr => pr.Story)  // Assuming a navigation property to Prompts
                .WithMany(p => p.StoryReactions)  // Assuming Prompts has a collection of PromptsReactions
                .HasForeignKey(pr => pr.StoryIdFK)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete

            // Configuring the relationship between PromptsReactions and another entity, e.g., User or Reaction
            modelBuilder.Entity<StoryReactions>()
                .HasOne(pr => pr.User)  // Assuming a navigation property to User or another entity
                .WithMany(u => u.StoryReactions)  // Assuming User or Reaction has a collection of PromptsReactions
                .HasForeignKey(pr => pr.UserIdFK)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete




            // ------------ Disable deletebehavior for stories -------------
            modelBuilder.Entity<Story>()
                .HasOne(st => st.Prompt)  // Assuming a navigation property to Prompts
                .WithMany(st => st.Stories)  // Assuming Prompts has a collection of PromptsReactions
                .HasForeignKey(st => st.PromptIdFK)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete
        }
    }
    
}
