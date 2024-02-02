using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Registration.Context;
using Registration.Pages;

public class RegisterModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public RegisterModel(ApplicationDbContext context)
    {
        _context = context;
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

        // TODO: Add validation for username and password

        // Create a new user object
        Users newUser = new Users
        {
            Username = username,
            Password = password
        };

        // Add the new user to the database
        _context.Users.Add(newUser);
        _context.SaveChanges();

        // Redirect to login page after registration
        return RedirectToPage("Login");
    }
}
