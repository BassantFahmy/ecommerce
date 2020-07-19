using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data
{
    public class EcommerceRepository : IecommerceRepository
    {
        private readonly DataContext _context;
        public EcommerceRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }
        public async Task<Country> GetCountry(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            return country;
        }
        public async Task<bool> CountryExists(string country)
        {
            if (await _context.Countries.AnyAsync(c => c.CountryName == country))
                return true;
            return false;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
