using BusinessLogic.AdminLogic;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAdminFunctions adminFunctions)
        {
            AdminFunctions = adminFunctions;
        }

        public IAdminFunctions AdminFunctions { get; }

        // POST api/<AuthenticationController>
        [HttpPost("TestAPI")]
        public void Post()
        {
            AdminFunctions.SetCourse("jjjs", 2, "das");
        }

        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
