using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.DataAccess;
using ECommerce.Entities;
using ECommerce.Core.Abstractions;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                IEnumerable<User> result = await _usersService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to get All Users:{ex.Message}");
            }
        }

        // GET: api/Users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersCart(int id)
        {
            try
            {
                User user = await _usersService.GetUser(id);

                if (user == null)
                {
                    return BadRequest();
                }

                IEnumerable<Cart> result = await _usersService.GetUserCarts(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to get All Users' Carts:{ex.Message}");
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                User user = await _usersService.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to get User:{ex.Message}");
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var exist = await _usersService.GetUser(id) != null;
            if (!exist)
            {
                return NotFound();
            }

            try
            {
                await _usersService.UpdateUser(user);
                return Ok();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update a user:{ex.Message}");
            }
        }
    }
}
