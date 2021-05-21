using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementDAL;
using UserManagementRepository.Interfaces;
using UserManagementRepository.Models;

namespace UserManagementRepository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        AppDbContext _context
        {
            get{
                return _dbContext as AppDbContext;
            }
        }

        public UserRepository(AppDbContext db): base(db)
        {

        }
        public IEnumerable<UserModel> GetUserWithCountryCity()
        {
            var data = (from usr in _context.Users
                        join c in _context.Cities on usr.CityId equals c.CityId
                        join con in _context.Countries
                        on c.CountryId equals con.CountryId
                        select new UserModel
                        {
                            UserId = usr.UserId,
                            Name = usr.Name,
                            UserName = usr.UserName,
                            CityId = usr.CityId,
                            CityName = c.CityName,
                            CountryId = usr.CountryId,
                            CountryName = con.CountryName,
                            Gender = usr.Gender,
                            Contact = usr.Contact,
                            Terms = usr.Terms
                        }).ToList();
            return data;
        }
    }
}
