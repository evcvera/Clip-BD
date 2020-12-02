using Clip2020Api.Models;
using Clip2020Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clip2020Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private IUserCollection db = new UserCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await db.GetAllUsers());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserDetails(string id)
        {
            return Ok(await db.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if(user == null)

                return BadRequest();

            if(user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The user shouldn't be empty");
            }

            await db.InsertUser(user);

            return Created("Created", true); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, string id)
        {
            if (user == null)

                return BadRequest();

            if (user.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The user shouldn't be empty");
            }

            user.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateUser(user);

            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await db.DeleteUser(id);

            return NoContent();
        }
    }
}
