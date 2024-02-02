using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Registration.Context;
using System.Linq;

public class LoginModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(ApplicationDbContext context, ILogger<LoginModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        // This method handles HTTP GET requests for the page.
    }

    public IActionResult OnPost()
    {
        // This method handles HTTP POST requests for the page.

        // Retrieve user input from the form
        string username = Request.Form["Username"];
        string password = Request.Form["Password"];

        // TODO: Implement user authentication logic
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // User authenticated successfully
            // TODO: Implement further actions, such as setting a user session
            return RedirectToPage("/Index");
        }
        else
        {
            // Authentication failed
            // TODO: Handle failed login (e.g., show an error message)
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
