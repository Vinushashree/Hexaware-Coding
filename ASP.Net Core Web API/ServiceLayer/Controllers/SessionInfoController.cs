using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class SessionInfoController : ControllerBase
{
    private readonly ISessionInfoRepo _sessionRepo;

    public SessionInfoController(ISessionInfoRepo sessionRepo)
    {
        _sessionRepo = sessionRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SessionInfo>> GetAll()
    {
        return Ok(_sessionRepo.GetAllSessions());
    }

    [HttpGet("{id}")]
    public ActionResult<SessionInfo> GetById(int id)
    {
        var session = _sessionRepo.GetSessionById(id);
        if (session == null)
            return NotFound();
        return Ok(session);
    }

    [HttpPost]
    public ActionResult Create([FromBody] SessionInfo session)
    {
        _sessionRepo.AddSession(session);
        _sessionRepo.Save();
        return CreatedAtAction(nameof(GetById), new { id = session.SessionId }, session);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] SessionInfo session)
    {
        if (id != session.SessionId)
            return BadRequest("Session ID mismatch");

        var existing = _sessionRepo.GetSessionById(id);
        if (existing == null)
            return NotFound();

        _sessionRepo.UpdateSession(session);
        _sessionRepo.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var session = _sessionRepo.GetSessionById(id);
        if (session == null)
            return NotFound();

        _sessionRepo.DeleteSession(id);
        _sessionRepo.Save();
        return NoContent();
    }
}

