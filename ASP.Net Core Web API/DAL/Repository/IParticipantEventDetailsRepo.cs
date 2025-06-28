using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface IParticipantEventDetailsRepo
    {
        IEnumerable<ParticipantEventDetails> GetAllParticipantDetails();
        ParticipantEventDetails GetParticipantDetailById(int id);
        void AddParticipantDetail(ParticipantEventDetails detail);
        void UpdateParticipantDetail(ParticipantEventDetails detail);
        void DeleteParticipantDetail(int id);
        void Save();
    }
}

