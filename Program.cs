
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data;
using StoryPromptAPI.Data.Repository;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models;
using StoryPromptAPI.Services.IServices;
using StoryPromptAPI.Services;

namespace StoryPromptAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<StoryPromptContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<StoryPromptContext>()
                .AddDefaultTokenProviders();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IPromptRepository, PromptRepository>();
            builder.Services.AddScoped<IStoryRepository, StoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IPromptReactionRepository, PromptReactionRepository>();
            builder.Services.AddScoped<IStoryReactionRepository, StoryReactionRepository>();

            builder.Services.AddScoped<IPromptService, PromptService>();
            builder.Services.AddScoped<IStoryService, StoryService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IPromptReactionService, PromptReactionService>();
            builder.Services.AddScoped<IStoryReactionService, StoryReactionService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
