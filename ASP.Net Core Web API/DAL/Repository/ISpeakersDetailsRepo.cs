using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repository
{
    public interface ISpeakersDetailsRepo
    {
        IEnumerable<SpeakersDetails> GetAllSpeakers();
        SpeakersDetails GetSpeakerById(int id);
        void AddSpeaker(SpeakersDetails speaker);
        void UpdateSpeaker(SpeakersDetails speaker);
        void DeleteSpeaker(int id);
        void Save();
    }
}
