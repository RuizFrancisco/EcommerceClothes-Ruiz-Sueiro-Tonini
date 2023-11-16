﻿using EcommerceClothes.Models;
using EcommerceClothes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        [Authorize("AdminPolicy")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _userService.GetById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetByName/{name}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(_userService.GetByUserName(name));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("CreateClient")]
        [Authorize("BothPolicy")]
        public IActionResult CreateClient([FromBody] UserDTO userDTO)
        {

            _userService.AddClient(userDTO);
            return StatusCode(201);
        }

        [HttpPost("CreateAdmin")]
        [Authorize("AdminPolicy")]
        public IActionResult CreateAdmin([FromBody] UserDTO adminDTO)
        {

            _userService.AddAdmin(adminDTO);
            return StatusCode(201);
        }


        [HttpPut("UpdateUser/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult Update(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.Update(id, userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
