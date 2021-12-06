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
    public class HallController : Controller
    {
        private readonly CRContext _context;

        public HallController(CRContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var halls = await _context.Halls
                .Include(e => e.Events)
                .Include(s => s.Seats)
                .ToListAsync();

            List<HallModel> hallModel = new();

            foreach(var h in halls)
            {
                var model = new HallModel()
                {
                    Name = h.Name,
                    NumberOfSeats = h.Seats.Count,
                    NumberOfEvents = 0
                };

                if(h.Events.Count > 0)
                {
                    var nearestDate = h.Events.DefaultIfEmpty().Where(x => x.BeginTime > DateTime.Now).Min(x => x.BeginTime);

                    model.NearestEvent = h.Events.FirstOrDefault(x => x.BeginTime == nearestDate);
                    model.NumberOfEvents = h.Events.Count(x => x.BeginTime > DateTime.Now);
                }

                hallModel.Add(model);
            }
                
            return View(hallModel);
        }
    }

    public class HallModel
    {
        public string Name { get; set; }
        public Event NearestEvent { get; set; }
        public int NumberOfEvents { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
