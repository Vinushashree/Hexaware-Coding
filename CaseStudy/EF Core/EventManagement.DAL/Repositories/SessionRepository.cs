using System.Collections.Generic;
using System.Linq;
using EventManagement.DAL.Entities;

namespace EventManagement.DAL.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly EventDbContext _context;

        public SessionRepository(EventDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SessionInfo> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public SessionInfo GetSessionById(int id)
        {
            return _context.Sessions.Find(id);
        }

        public void AddSession(SessionInfo session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public void UpdateSession(SessionInfo session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }

        public void DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                _context.SaveChanges();
            }
        }
    }
}
