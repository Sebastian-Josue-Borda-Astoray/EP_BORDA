using Microsoft.AspNetCore.Mvc;
using EP_Borda.Models;
using EP_Borda.Data; // donde esté tu DbContext
using Microsoft.EntityFrameworkCore;

namespace EP_Borda.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player, int TeamId)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                // Asociación al equipo seleccionado
                var assignment = new Assignment
                {
                    PlayerId = player.Id,
                    TeamId = TeamId
                };

                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); // o donde quieras
            }

            ViewBag.Teams = _context.Teams.ToList();
            return View(player);
        }
    }
}
