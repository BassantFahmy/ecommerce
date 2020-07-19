using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.Data;
using ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IecommerceRepository _repo;
        private readonly IMapper _mapper;
        public CountryController(IecommerceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Country
        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> Get()
        {

            var countries = await _repo.GetCountries();

            return Ok(new
            {
                countries,
                StatusCode = 200
            });
        }

        // GET: api/Country/5
        [HttpGet("{id}", Name = "GetCountry")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _repo.GetCountry(id);
            return Ok(new
            {
                country,
                StatusCode = 200
            });
        }

        // POST: api/Country
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country country)
        {

            if (await _repo.CountryExists(country.CountryName))
                return BadRequest("Country already exists");

            if (country == null)
                return null;
            _repo.Add(country);
            if (await _repo.SaveAll())
            {

                return Ok(new
                {
                    message = "Country has been added successfully.",
                    StatusCode = 200
                });
            }
            throw new Exception("Something went wrong.");

        }

        // PUT: api/Country/5
        /*  [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var countryFromRepo = await _repo.GetCountry(id);


            _repo.Delete(countryFromRepo);


            if (await _repo.SaveAll())
                return Ok(new
                {
                    message = "Country has been deleted successfully.",
                    StatusCode = 200
                });

            throw new Exception("Error deleting the message");
        }
    }
}
