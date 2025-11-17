using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        public List<MediaItem> MediaItems { get; set; }
      
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            MediaItems = new List<MediaItem>
        {
            new MediaItem { Quality = "HD", Title = "One Battle After Another", Year = 2025, Duration = 162, Type = "Movie" },
            new MediaItem { Quality = "HD", Title = "Frankenstein", Year = 2025, Duration = 150, Type = "Movie" },
            new MediaItem { Quality = "CAM", Title = "Now You See Me: Now You Don't", Year = 2025, Duration = 112, Type = "Movie" },
            new MediaItem { Quality = "HD", Title = "Tracker", Type = "TV", Season = 3, Episode = 5 }
            // You can add more here...
        };

        }
    }
}
