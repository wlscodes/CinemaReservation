using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaReservation.Context;
using CinemaReservation.Models;
using CinemaReservation.Modules;

namespace CinemaReservation.Controllers
{
    public class EventController : Controller
    {
        private readonly CRContext _context;

        /// <summary>
        /// Maksymalna ilość wydarzeń wyświetlanych na stronie
        /// </summary>
        private readonly int _pageSize;

        public EventController(CRContext context)
        {
            _context = context;
            _pageSize = 7;
        }

        // GET: Event
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var events = _context.Events.Include(x => x.Hall).Where(x => x.FinishTime > DateTime.Now).OrderBy(x => x.BeginTime);

            return View(await PaginatedList<Event>.CreateAsync(events, pageNumber ?? 1, _pageSize));
        }

        // POST: Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string eventName)
        {
            eventName = eventName ?? String.Empty;

            var events = _context.Events
                .Include(x => x.Hall)
                .Where(x => x.FinishTime > DateTime.Now && x.Name.ToLower().Contains(eventName.ToLower()))
                .OrderBy(x => x.BeginTime);

            return View(await PaginatedList<Event>.CreateAsync(events, 1, int.MaxValue));
        }

        // GET: Event/Details/{id}
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventData = await _context.Events
                .Include(h => h.Hall)
                .ThenInclude(s => s.Seats)
                .Include(t => t.Tickets)
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();

            if (eventData == null)
            {
                return NotFound();
            }

            return View(eventData);
        }

        // POST: Event/Details/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Guid eventID, IList<Guid> seats)
        {
            if(!EventExists(eventID))
            {
                return NotFound();
            }

            if(seats?.Count == 0)
            {
                TempData["Error"] = "Nie wybrano miejsc";
                ModelState.AddModelError(nameof(seats), TempData["Error"].ToString());
            }

            // Sprawdzenie, czy jakieś miejsca są już zajęte
            var reservedSeats = await _context.Tickets.Where(x => x.EventID == eventID && seats.Contains(x.SeatID)).ToListAsync();
            if(reservedSeats?.Count != 0)
            {
                TempData["Error"] = "Niektóre z podanych miejsc są już zajęte";
                ModelState.AddModelError(nameof(seats), TempData["Error"].ToString());
            }

            if (ModelState.IsValid)
            {
                List<Ticket> tickets = new();
                seats.ToList().ForEach(x => tickets.Add(new Ticket()
                {
                    BougthDate = DateTime.Now,
                    EventID = eventID,
                    SeatID = x
                }));

                await _context.Tickets.AddRangeAsync(tickets);
                await _context.SaveChangesAsync();

                return RedirectToAction("List", "Ticket", new { eventId = eventID, tickets = tickets.Select(x => x.ID).ToList() });
            }
            return RedirectToAction(nameof(Details), eventID);
        }

        // GET: Event/Create
        public async Task<IActionResult> Create()
        {
            ViewData["HallID"] = await GetHallsSelectList();
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BeginTime,FinishTime,HallID")] Event eventData)
        {
            if(eventData.HallID == Guid.Empty)
            {
                ModelState.AddModelError(nameof(eventData.HallID), "Sala nie została wybrana");
            }

            if(eventData.BeginTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(eventData.BeginTime), "Data nie może być z przeszłości");
            }

            if(eventData.BeginTime >= eventData.FinishTime)
            {
                ModelState.AddModelError(nameof(eventData.FinishTime), "Data zakończenia nie może być młodsza niż data rozpoczęcia");
            }

            if(await CheckEventDateCollision(eventData))
            {
                ModelState.AddModelError(nameof(eventData.BeginTime), "W podanym przedziale czasowym istnieje już jakieś wydarzenie");
            }

            if (ModelState.IsValid)
            {
                eventData.ID = Guid.NewGuid();
                _context.Add(eventData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HallID"] = await GetHallsSelectList(eventData.HallID);
            return View(eventData);
        }

        // GET: Event/Edit/{id}
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventData = await _context.Events.FindAsync(id);
            if (eventData == null)
            {
                return NotFound();
            }
            ViewData["HallID"] = await GetHallsSelectList(eventData.HallID);
            return View(eventData);
        }

        // POST: Event/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,BeginTime,FinishTime,HallID")] Event eventData)
        {
            if (id != eventData.ID)
            {
                return NotFound();
            }

            if (eventData.HallID == Guid.Empty)
            {
                ModelState.AddModelError(nameof(eventData.HallID), "Sala nie została wybrana");
            }

            if (eventData.BeginTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(eventData.BeginTime), "Data nie może być z przeszłości");
            }

            if (eventData.BeginTime >= eventData.FinishTime)
            {
                ModelState.AddModelError(nameof(eventData.FinishTime), "Data zakończenia nie może być młodsza niż data rozpoczęcia");
            }

            if (await CheckEventDateCollision(eventData))
            {
                ModelState.AddModelError(nameof(eventData.BeginTime), "W podanym przedziale czasowym istnieje już jakieś wydarzenie");
            }

            var ticketsForUpdate = _context.Tickets.Where(x => x.EventID == eventData.ID);
            if(await ticketsForUpdate.AnyAsync())
            {
                ModelState.AddModelError(nameof(eventData.HallID), "Nie można zmienić sali, jeżeli jakiekolwiej miejsce jest zarezerwowane");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventData);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventData.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HallID"] = await GetHallsSelectList(eventData.HallID);
            return View(eventData);
        }

        // GET: Event/Delete/{id}
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var eventData = await _context.Events
                .Include(x => x.Hall)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (eventData is null)
            {
                return NotFound();
            }

            return View(eventData);
        }

        // POST: Event/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eventData = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Sprawdź czy event o danym ID istnieje
        /// </summary>
        /// <param name="id">ID eventu</param>
        /// <returns>Zwraca true jeśli event o takim ID istnieje w bazie danych</returns>
        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.ID == id);
        }

        /// <summary>
        /// Pobierz listę dostępnych sal kinowych
        /// </summary>
        /// <returns>Lista sal kinowych</returns>
        private async Task<SelectList> GetHallsSelectList() => await GetHallsSelectList(Guid.Empty);

        /// <summary>
        /// Pobierz listę dostępnych sal kinowych
        /// </summary>
        /// <param name="selected">ID wybranej sali</param>
        /// <returns>Lista sal kinowych</returns>
        private async Task<SelectList> GetHallsSelectList(Guid selected)
        {
            List<Hall> halls = await _context.Halls.OrderBy(x => x.Name).ToListAsync();
            halls.Insert(0, new Hall() { Name = "-- Wybierz salę --" });
            return new SelectList(halls, "ID", "Name", selected);
        }

        /// <summary>
        /// Sprawdź czy sala jest zajęta w danym przedziale czasowym
        /// </summary>
        /// <param name="eventData">Obiekt wydarzenia</param>
        /// <returns>Zwraca true jeżeli sala jest zajęta</returns>
        private async Task<bool> CheckEventDateCollision(Event eventData)
        {
            return await _context.Events.Where(x => x.ID != eventData.ID && x.HallID == eventData.HallID && ((eventData.BeginTime >= x.BeginTime && eventData.BeginTime <= x.FinishTime) || (eventData.FinishTime >= x.BeginTime && eventData.FinishTime <= x.FinishTime)) ).AnyAsync();
        }
    }
}
