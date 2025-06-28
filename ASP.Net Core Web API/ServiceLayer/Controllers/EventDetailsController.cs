using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class EventDetailsController : ControllerBase
{
    private readonly IEventDetailsRepo _eventRepo;

    public EventDetailsController(IEventDetailsRepo eventRepo)
    {
        _eventRepo = eventRepo;
    }

    // GET: api/EventDetails
    [HttpGet]
    public ActionResult<IEnumerable<EventDetails>> GetAll()
    {
        return Ok(_eventRepo.GetAllEvents());
    }

    // GET: api/EventDetails/{id}
    [HttpGet("{id}")]
    public ActionResult<EventDetails> GetById(int id)
    {
        var ev = _eventRepo.GetEventById(id);
        if (ev == null)
            return NotFound();
        return Ok(ev);
    }

    // POST: api/EventDetails
    [HttpPost]
    public ActionResult Create([FromBody] EventDetails ev)
    {
        _eventRepo.AddEvent(ev);
        _eventRepo.Save();
        return CreatedAtAction(nameof(GetById), new { id = ev.EventId }, ev);
    }

    // PUT: api/EventDetails/{id}
    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] EventDetails ev)
    {
        if (id != ev.EventId)
            return BadRequest("Event ID mismatch");

        var existing = _eventRepo.GetEventById(id);
        if (existing == null)
            return NotFound();

        _eventRepo.UpdateEvent(ev);
        _eventRepo.Save();
        return NoContent();
    }

    // DELETE: api/EventDetails/{id}
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var ev = _eventRepo.GetEventById(id);
        if (ev == null)
            return NotFound();

        _eventRepo.DeleteEvent(id);
        _eventRepo.Save();
        return NoContent();
    }
}
