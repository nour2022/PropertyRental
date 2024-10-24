﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PropertyRental.Application.DTOs;
using PropertyRental.Application.Services;
using PropertyRental.Domain.Entities.User;

namespace PropertyRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserAppService _userService;
        private RoleManager<Role> _roleManager;
        private UserManager<User> _userManager;

        public UserController(UserAppService userService, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);
            if(user == null) { return NotFound(); }
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateInfo([FromBody] UserDTO userDTO, int id)
        {
            _userService.Update(userDTO, id);
            return Ok();
        
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody]UserDTO user)
        {
           
             await _userService.Insert(user);
               
           
            return Ok();
        }
       
        
    }
}