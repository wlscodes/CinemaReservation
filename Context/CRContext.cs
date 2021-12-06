using CinemaReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservation.Context
{
    public class CRContext : DbContext
    {
        public CRContext(DbContextOptions<CRContext> options) : base(options) { }

        public DbSet<Hall> Halls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacja Hall - Seat
            modelBuilder.Entity<Seat>()
                .HasOne<Hall>(h => h.Hall)
                .WithMany(s => s.Seats)
                .HasForeignKey(h => h.HallID)
                .OnDelete(DeleteBehavior.Cascade);
                

            // Relacja Hall - Event
            modelBuilder.Entity<Event>()
                .HasOne<Hall>(h => h.Hall)
                .WithMany(e => e.Events)
                .HasForeignKey(h => h.HallID)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja Event - Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne<Event>(e => e.Event)
                .WithMany(t => t.Tickets)
                .HasForeignKey(e => e.EventID)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja Seat - Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne<Seat>(s => s.Seat)
                .WithMany(t => t.Tickets)
                .HasForeignKey(s => s.SeatID)
                .OnDelete(DeleteBehavior.NoAction);

            // Stworzenie dwóch sal
            var halls = new List<Hall>()
            {
                new Hall(){ ID = Guid.NewGuid(), Name = "Sala 1" },
                new Hall(){ ID = Guid.NewGuid(), Name = "Sala 2" }
            };

            modelBuilder.Entity<Hall>().HasData(halls);

            List<Seat> seats = new();

            // Wygenerowanie miejsc w salach
            halls.ForEach(x => seats.AddRange(GenerateHallSeats(x, 15, 15)));

            modelBuilder.Entity<Seat>().HasData(seats);
        }

        private static IEnumerable<Seat> GenerateHallSeats(Hall hall, int rows, int columns)
        {
            for (short i = 0; i < rows; i++)
            {
                for (short j = 0; j < columns; j++)
                {
                    yield return new Seat()
                    {
                        Row = i,
                        Column = j,
                        HallID = hall.ID,
                        ID = Guid.NewGuid()
                    };
                }
            }
        }
    }
}
