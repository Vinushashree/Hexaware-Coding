using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class SpeakersDetailsController : ControllerBase
{
    private readonly ISpeakersDetailsRepo _speakerRepo;

    public SpeakersDetailsController(ISpeakersDetailsRepo speakerRepo)
    {
        _speakerRepo = speakerRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SpeakersDetails>> GetAll()
    {
        return Ok(_speakerRepo.GetAllSpeakers());
    }

    [HttpGet("{id}")]
    public ActionResult<SpeakersDetails> GetById(int id)
    {
        var speaker = _speakerRepo.GetSpeakerById(id);
        if (speaker == null)
            return NotFound();
        return Ok(speaker);
    }

    [HttpPost]
    public ActionResult Create([FromBody] SpeakersDetails speaker)
    {
        _speakerRepo.AddSpeaker(speaker);
        _speakerRepo.Save();
        return CreatedAtAction(nameof(GetById), new { id = speaker.SpeakerId }, speaker);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] SpeakersDetails speaker)
    {
        if (id != speaker.SpeakerId)
            return BadRequest("Speaker ID mismatch");

        var existing = _speakerRepo.GetSpeakerById(id);
        if (existing == null)
            return NotFound();

        _speakerRepo.UpdateSpeaker(speaker);
        _speakerRepo.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var speaker = _speakerRepo.GetSpeakerById(id);
        if (speaker == null)
            return NotFound();

        _speakerRepo.DeleteSpeaker(id);
        _speakerRepo.Save();
        return NoContent();
    }
}
