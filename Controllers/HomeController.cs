using CinemaReservation.Context;
using CinemaReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly CRContext _context;

        public HomeController(CRContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = new Dictionary<string, Event>();

            if(!await _context.Events.AnyAsync())
            {
                return View(result);
            }

            // Wyszukanie najblizszego wydarzenia
            var lastTime = await _context.Events.Where(x => x.BeginTime > DateTime.Now).MinAsync(x => x.BeginTime);
            var lastTimeEvent = await _context.Events.Where(x => x.BeginTime == lastTime).FirstOrDefaultAsync();

            result.Add("Najbliższe wydarzenie", lastTimeEvent);

            // Wyszukanie wydarzenia, które ma najmniej wolnych miejsc
            var lastSeats = await _context.Events
                .Include(x => x.Tickets)
                .Include(x => x.Hall)
                    .ThenInclude(x => x.Seats)
                .Where(x => x.BeginTime > DateTime.Now)
                .Select(s => new
                {
                    EventData = s,
                    TotalSeats = s.Hall.Seats.Count,
                    Tickets = s.Tickets.Count
                })
                .Where(x => x.TotalSeats > x.Tickets)
                .OrderBy(x => x.TotalSeats - x.Tickets)
                .Select(x => x.EventData).FirstOrDefaultAsync();

            result.Add("Ostatnie bilety", lastSeats);

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
