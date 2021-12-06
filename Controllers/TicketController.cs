using CinemaReservation.Context;
using CinemaReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaReservation.Controllers
{
    public class TicketController : Controller
    {
        private readonly CRContext _context;

        public TicketController(CRContext context)
        {
            _context = context;
        }

        // GET: Ticket/List
        public async Task<IActionResult> List(Guid eventId, IList<Guid> tickets)
        {
            var ticketList = _context.Tickets
                .Include(e => e.Event)
                .Include(s => s.Seat)
                    .ThenInclude(h => h.Hall)
                .Where(x => tickets.Contains(x.ID))
                .ToListAsync();

            var result = new Dictionary<Guid, IList<Ticket>>();
            result.Add(eventId, await ticketList);
         
            return View(result);
        }
    }
}
