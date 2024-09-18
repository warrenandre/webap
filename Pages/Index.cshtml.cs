using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webap.Data;

namespace webap.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            try
            {
                // Query the database
                var data = _dbContext.Users.ToList(); // Replace 'SomeTable' with your actual DbSet

                // Display success message
                ViewData["Message"] = "Database query successful.";
                ViewData["Data"] = data; // Store the queried data in ViewData
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while querying the database.");
                ViewData["Message"] = "An error occurred while querying the database.";
            }
        }
    }
}
