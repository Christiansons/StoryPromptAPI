using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Models;

namespace StoryPromptAPI.Data
{
    public class StoryPromptContext : IdentityDbContext<User>
    {
        public StoryPromptContext(DbContextOptions<StoryPromptContext> options) : base (options) { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<PromptReactions> PromptsReactions { get; set; }
        public DbSet<StoryReactions> StoriesReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PromptReactions>()
         .HasOne(pr => pr.Prompt)
         .WithMany(p => p.PromptsReactions)
         .HasForeignKey(pr => pr.PromptId)
         .OnDelete(DeleteBehavior.Restrict);  // Prevent multiple cascade paths

            // Configure one-to-many relationship between Users and PromptReaction with Cascade
            modelBuilder.Entity<PromptReactions>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.PromptsReactions)
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete when a user is deleted

            // Configure one-to-many relationship between Story and StoryReaction with Restrict (to avoid multiple cascade paths)
            modelBuilder.Entity<StoryReactions>()
                .HasOne(sr => sr.Story)
                .WithMany(s => s.StoriesReactions)
                .HasForeignKey(sr => sr.StoryId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent multiple cascade paths

            // Configure one-to-many relationship between Users and StoryReaction with Cascade
            modelBuilder.Entity<StoryReactions>()
                .HasOne(sr => sr.User)
                .WithMany(u => u.StoriesReactions)
                .HasForeignKey(sr => sr.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete when a user is deleted

            // Configure one-to-many relationship between Stories and Prompts with Restrict (to avoid multiple cascade paths)
            modelBuilder.Entity<Story>()
                .HasOne(s => s.Prompt)
                .WithMany(p => p.Stories)
                .HasForeignKey(s => s.PromptId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent multiple cascade paths

            // Configure one-to-many relationship between Users and Stories with Cascade
            modelBuilder.Entity<Story>()
                .HasOne(s => s.User)
                .WithMany(u => u.Stories)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
    
}
