using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserLogin User { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Shows validation errors automatically
            }

            // Example: Validate the ID (here you can add more logic if needed)
            if (User.IdNumber.Length != 13)
            {
                ModelState.AddModelError("User.IdNumber", "ID number must be exactly 13 digits.");
                return Page();
            }

            // For demonstration, you can pretend login succeeds
            return RedirectToPage("/Index"); // Or redirect to another page
        }
    }
}
