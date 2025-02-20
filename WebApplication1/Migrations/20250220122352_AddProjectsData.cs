using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddProjectsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert seed data into Projects table
            migrationBuilder.Sql(@"
                INSERT INTO Projects (Title, Description, Link, ImageUrl, VideoUrl)
                VALUES
                ('Fear Of Neighbours', 'I was working as a gameplay programmer in 5 person team in this VR game Made in Unity.', 'https://store.steampowered.com/app/2333040/Fear_of_Neighbours/', 'https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2333040/header.jpg?t=1686906484', 'https://video.fastly.steamstatic.com/store_trailers/256950586/movie_max_vp9.webm?t=1686906441'),
                ('E-commerce App', 'A fully functional e-commerce web app with shopping cart and payment integration.', 'https://github.com/yourusername/ecommerceapp', 'https://example.com/ecommerce_image.jpg', 'https://example.com/ecommerce_video.mp4'),
                ('E-commerce App', 'A fully functional e-commerce web app with shopping cart and payment integration.', 'https://github.com/yourusername/ecommerceapp', 'https://example.com/ecommerce_image.jpg', 'https://example.com/ecommerce_video.mp4');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seed data if rolling back
            migrationBuilder.Sql("DELETE FROM Projects WHERE Title IN ('Fear Of Neighbours', 'E-commerce App');");
        }
    }
}
