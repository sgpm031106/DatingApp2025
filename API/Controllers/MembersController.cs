using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var members = context.Users.ToList();

            return members;
        }

        [HttpGet("{id}")] // https://localhost:5001/api/members/bob-id

        public ActionResult<AppUser> GetMember(string id)
        {
            var member = context.Users.Find(id);

            if (member == null) return NotFound();

            return member;
        }
    }
}
