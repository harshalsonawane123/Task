using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ActiveNodeController : Controller
    {
        private readonly NodeDbContext _context;

        public ActiveNodeController(NodeDbContext context)
        {
            _context = context;
        }

        // Your controller actions go here
    }

}
