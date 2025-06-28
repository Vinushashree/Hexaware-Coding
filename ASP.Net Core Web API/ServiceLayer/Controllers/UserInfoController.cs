using DAL.Models;              // For UserInfo
using DAL.Repository;          // For IUserInfoRepo
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepo _userRepo;

        public UserInfoController(IUserInfoRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: api/UserInfo
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> GetAll()
        {
            return Ok(_userRepo.GetAllUsers());
        }

        // GET: api/UserInfo/{email}
        [HttpGet("{email}")]
        public ActionResult<UserInfo> GetByEmail(string email)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/UserInfo
        [HttpPost]
        public ActionResult Create([FromBody] UserInfo user)
        {
            _userRepo.AddUser(user);
            _userRepo.Save();
            return CreatedAtAction(nameof(GetByEmail), new { email = user.EmailId }, user);
        }

        // PUT: api/UserInfo/{email}
        [HttpPut("{email}")]
        public ActionResult Update(string email, [FromBody] UserInfo user)
        {
            if (email != user.EmailId)
                return BadRequest("Email mismatch");

            var existing = _userRepo.GetUserByEmail(email);
            if (existing == null)
                return NotFound();

            _userRepo.UpdateUser(user);
            _userRepo.Save();
            return NoContent();
        }

        // DELETE: api/UserInfo/{email}
        [HttpDelete("{email}")]
        public ActionResult Delete(string email)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user == null)
                return NotFound();

            _userRepo.DeleteUser(email);
            _userRepo.Save();
            return NoContent();
        }
    }
}

