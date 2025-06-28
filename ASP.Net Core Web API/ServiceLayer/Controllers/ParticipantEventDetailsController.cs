using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ParticipantEventDetailsController : ControllerBase
{
    private readonly IParticipantEventDetailsRepo _participantRepo;

    public ParticipantEventDetailsController(IParticipantEventDetailsRepo participantRepo)
    {
        _participantRepo = participantRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ParticipantEventDetails>> GetAll()
    {
        return Ok(_participantRepo.GetAllParticipantDetails());
    }

    [HttpGet("{id}")]
    public ActionResult<ParticipantEventDetails> GetById(int id)
    {
        var detail = _participantRepo.GetParticipantDetailById(id);
        if (detail == null)
            return NotFound();
        return Ok(detail);
    }

    [HttpPost]
    public ActionResult Create([FromBody] ParticipantEventDetails detail)
    {
        _participantRepo.AddParticipantDetail(detail);
        _participantRepo.Save();
        return CreatedAtAction(nameof(GetById), new { id = detail.Id }, detail);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] ParticipantEventDetails detail)
    {
        if (id != detail.Id)
            return BadRequest("ID mismatch");

        var existing = _participantRepo.GetParticipantDetailById(id);
        if (existing == null)
            return NotFound();

        _participantRepo.UpdateParticipantDetail(detail);
        _participantRepo.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var detail = _participantRepo.GetParticipantDetailById(id);
        if (detail == null)
            return NotFound();

        _participantRepo.DeleteParticipantDetail(id);
        _participantRepo.Save();
        return NoContent();
    }
}

