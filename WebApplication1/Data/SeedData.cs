using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (!context.Projects.Any())
            {
                // Adding new Projects
                context.Projects.AddRange(
                    new Project
                    {
                        Title = "Fear Of Neighbours",
                        Description = "I was working as a gameplay programmer in a 5-person team on this VR game Made in Unity.",
                        Link = "https://store.steampowered.com/app/2333040/Fear_of_Neighbours/",
                        ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2333040/header.jpg?t=1686906484",
                        VideoUrl = "https://video.fastly.steamstatic.com/store_trailers/256950586/movie_max_vp9.webm?t=1686906441"
                    },
                    new Project
                    {
                        Title = "E-commerce App",
                        Description = "A fully functional e-commerce web app with shopping cart and payment integration.",
                        Link = "https://github.com/yourusername/ecommerceapp",
                        ImageUrl = "https://example.com/ecommerce_image.jpg",
                        VideoUrl = "https://example.com/ecommerce_video.mp4"
                    }
                );

                // Save the changes to the database
                context.SaveChanges();
            }
            else
            {
                // If projects exist, you can modify the existing ones here
                var project = context.Projects.FirstOrDefault(p => p.Title == "E-commerce App");
                if (project != null)
                {
                    project.Description = "Updated description for the E-commerce app.";
                    context.SaveChanges();  // Update the record
                }
            }
        }

    }
}
