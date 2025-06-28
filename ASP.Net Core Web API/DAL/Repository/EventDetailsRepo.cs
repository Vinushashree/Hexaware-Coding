using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class EventDetailsRepo : IEventDetailsRepo
    {
        private readonly ApplicationDbContext _context;

        public EventDetailsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventDetails> GetAllEvents()
        {
            return _context.EventDetails
                           .Include(e => e.Sessions)
                           .Include(e => e.Participants)
                           .ToList();
        }

        public EventDetails GetEventById(int id)
        {
            return _context.EventDetails
                           .Include(e => e.Sessions)
                           .Include(e => e.Participants)
                           .FirstOrDefault(e => e.EventId == id);
        }

        public void AddEvent(EventDetails ev)
        {
            _context.EventDetails.Add(ev);
        }

        public void UpdateEvent(EventDetails ev)
        {
            _context.Entry(ev).State = EntityState.Modified;
        }

        public void DeleteEvent(int id)
        {
            var ev = _context.EventDetails.Find(id);
            if (ev != null)
                _context.EventDetails.Remove(ev);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
