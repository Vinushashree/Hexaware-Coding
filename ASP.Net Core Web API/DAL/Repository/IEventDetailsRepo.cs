using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository // ✅ This must match your 'using' in controller
{
    public interface IEventDetailsRepo
    {
        IEnumerable<EventDetails> GetAllEvents();
        EventDetails GetEventById(int id);
        void AddEvent(EventDetails ev);
        void UpdateEvent(EventDetails ev);
        void DeleteEvent(int id);
        void Save();
    }
}

