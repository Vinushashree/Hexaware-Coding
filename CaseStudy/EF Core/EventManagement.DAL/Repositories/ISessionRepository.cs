using System.Collections.Generic;
using EventManagement.DAL.Entities;

namespace EventManagement.DAL.Repositories
{
    public interface ISessionRepository
    {
        IEnumerable<SessionInfo> GetAllSessions();
        SessionInfo GetSessionById(int id);
        void AddSession(SessionInfo session);
        void UpdateSession(SessionInfo session);
        void DeleteSession(int id);
    }
}

