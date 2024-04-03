using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> listUsers = new List<UserDto>(){
            new UserDto()
            {
                Firstname = "Bill",
                Lastname = "Gates",
                Email = "billgates@gmail.com",
                Phone = "071111111",
                Address = "New York, USA",
            },
            new UserDto()
            {
                Firstname = "Bob",
                Lastname = "Smith",
                Email = "bobsmith@gmail.com",
                Phone = "07332444234",
                Address = "New York, USA",
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (listUsers.Count > 0)
            {
                return Ok(listUsers);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                return Ok(listUsers[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            listUsers.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto user)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                listUsers[id] = user;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                listUsers.RemoveAt(id);
            }
            return NoContent();
        }

    }
}
