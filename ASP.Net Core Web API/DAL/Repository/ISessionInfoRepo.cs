using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ISessionInfoRepo
    {
        IEnumerable<SessionInfo> GetAllSessions();
        SessionInfo GetSessionById(int id);
        void AddSession(SessionInfo session);
        void UpdateSession(SessionInfo session);
        void DeleteSession(int id);
        void Save();
    }
}

