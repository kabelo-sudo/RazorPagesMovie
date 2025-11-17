using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // This stores the uploaded movie file
        [BindProperty]
        public IFormFile MovieFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle movie upload
            if (MovieFile != null)
            {
                // Folder to save movies
                var movieFolder = Path.Combine("wwwroot", "movies");

                // Create folder if it doesn't exist
                if (!Directory.Exists(movieFolder))
                {
                    Directory.CreateDirectory(movieFolder);
                }

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(MovieFile.FileName);
                var filePath = Path.Combine(movieFolder, fileName);

                // Save the movie file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await MovieFile.CopyToAsync(stream);
                }

                // Save the file path to the database
                Movie.MovieFilePath = "/movies/" + fileName;
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
