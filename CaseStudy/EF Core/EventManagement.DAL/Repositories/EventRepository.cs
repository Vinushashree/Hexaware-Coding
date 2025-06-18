using System.Collections.Generic;
using System.Linq;
using EventManagement.DAL.Entities;

namespace EventManagement.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EventDetails> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public EventDetails GetEventById(int id)
        {
            return _context.Events.Find(id);
        }

        public void AddEvent(EventDetails ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();
        }

        public void UpdateEvent(EventDetails ev)
        {
            _context.Events.Update(ev);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }
        }
    }
}
