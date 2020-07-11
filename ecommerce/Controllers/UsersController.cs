using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.Data;
using ecommerce.Dtos;
using ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IecommerceRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IecommerceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(user);
            return Ok(userToReturn);
        }

       


        // DELETE: api/ApiWithActions/5
       /* [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
