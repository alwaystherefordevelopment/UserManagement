using Microsoft.AspNetCore.Mvc;
using SignUpPageChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementDAL;

namespace SignUpPageChallenge.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext _db;
        public AccountController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult SignUp()
        {
            var cList = _db.Cities.ToList();
            var countryList = _db.Countries.ToList();
            if(cList.Count == 0)
            {
                cList = new List<City>() { new City() { CityId = 1, CityName = "Bangalore", CountryId = 1 }, new City { CityId = 2, CityName = "Philladelphia", CountryId = 2 } };
            }
            if(countryList.Count ==0 )
            {
                countryList = new List<Country>() { new Country() { CountryId=1, CountryName="India"}, new Country() { CountryId=2, CountryName="USA"} };
            }
            ViewBag.CityList = cList;
            ViewBag.CountryList = countryList;
            ViewBag.GenderList = new List<string>() { "Male", "Female" };
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = new User()
                    {
                        Name = model.Name,
                        UserName = model.UserName,
                        Password = model.Password,
                        Contact=model.ContactNumber,
                        City = model.City,
                        Country = model.Country,
                        Gender = model.Gender,
                        Terms = model.Terms
                    };
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return RedirectToAction("SignUp");
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
