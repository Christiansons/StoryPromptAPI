
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoryPromptAPI.Data;
using StoryPromptAPI.Data.Repository;
using StoryPromptAPI.Data.Repository.IRepository;
using StoryPromptAPI.Models.Entities;

namespace StoryPromptAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPromptReactionRepository, PromptReactionRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            //builder.Services.AddScoped<IStoryReactionRepository, StoryReactionRepository>();
            //builder.Services.AddScoped<IPromptReactionRepository, IPromptReactionRepository>();
            //builder.Services.AddScoped<IPromptReactionRepository, IPromptReactionRepository>();
            //builder.Services.AddScoped<IPromptReactionRepository, IPromptReactionRepository>();
            //builder.Services.AddScoped<IPromptReactionRepository, IPromptReactionRepository>();

            builder.Services.AddDbContext<StoryPromptContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<StoryPromptContext>()
                .AddDefaultTokenProviders();

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
