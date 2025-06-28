using System.Collections.Generic;
using EventManagement.DAL.Entities;

namespace EventManagement.DAL.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<EventDetails> GetAllEvents();
        EventDetails GetEventById(int id);
        void AddEvent(EventDetails ev);
        void UpdateEvent(EventDetails ev);
        void DeleteEvent(int id);
    }
}
