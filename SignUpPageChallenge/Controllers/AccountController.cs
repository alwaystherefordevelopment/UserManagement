using Microsoft.AspNetCore.Mvc;
using UserManagementRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagementDAL;
using UserManagementRepository;
using UserManagementRepository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SignUpPageChallenge.Controllers
{
    public class AccountController : Controller
    {
        AppDbContext _db;
        IUserRepository _userRepo;
        IRepository<City> _city;
        IRepository<Country> _country;
        public AccountController(AppDbContext db, IUserRepository user, IRepository<City> city, IRepository<Country> country)
        {
            _db = db;
            _userRepo = user;
            _city = city;
            _country = country;
        }
        public IActionResult SignUp()
        {
            //var cList = _city.GetAll().ToList();
            //var countryList = _country.GetAll().ToList();
            //if(cList.Count == 0)
            //{
            //    cList = new List<City>() { new City() { CityId = 1, CityName = "Bangalore", CountryId = 1 }, new City { CityId = 2, CityName = "Philladelphia", CountryId = 2 } };
            //}
            //if(countryList.Count ==0 )
            //{
            //    countryList = new List<Country>() { new Country() { CountryId=1, CountryName="India"}, new Country() { CountryId=2, CountryName="USA"} };
            //}
            
            ViewBag.CountryList = GetCountry();
            ViewBag.GenderList = GetGender();
            return View();
        }

        public List<string> GetGender()
        {
            return new List<string>() { "Male", "Female" };
        }
        public List<Country> GetCountry()
        {
            return _country.GetAll().ToList();
        }
        public JsonResult GetCities(int id)
        {
            var cList = _city.GetAll().Where(c => c.CountryId == id).ToList();
            return Json(new SelectList(cList,"CityId","CityName"));
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepo.Add(model);
                    _userRepo.SaveChanges();
                        return RedirectToAction("Login");                                               
                }
                catch(Exception ex)
                {
                    return RedirectToAction("SignUp");
                }
            }
            return RedirectToAction("SignUp");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _userRepo.GetAll().Where(u=> u.UserName == model.UserName && u.Password == model.Password);
            if(user.Any())
            {
                return RedirectToAction("Details");
            }
            return View();
        }

        public IActionResult Details()
        {
            var user = _userRepo.GetUserWithCountryCity();
            return View(user);
        }

        public IActionResult Index()
        {
           return View();
        }
        
        public IActionResult Edit(int id)
        {
            ViewBag.CountryList = GetCountry().ToList();
            ViewBag.GenderList = GetGender();
            User model = _userRepo.Find(id);
            UserManagement.UI.Models.UserModel umodel = new UserManagement.UI.Models.UserModel
            {
                UserId = model.UserId,
                Name = model.Name,
                UserName = model.UserName,
                Password = model.Password,
                Contact = model.Contact,
                Gender = model.Gender,
                CityId = model.CityId,
                CountryId = model.CountryId,
                Terms = model.Terms
            };            
            return View("SignUp", umodel);
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    UserName = model.UserName,
                    Password = model.Password,
                    Contact = model.Contact,
                    Gender = model.Gender,
                    CountryId = model.CountryId,
                    CityId = model.CityId,
                    Terms = model.Terms
                };
                _userRepo.Update(user);
                _userRepo.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.CountryList = GetCountry().ToList();
            ViewBag.GenderList = GetGender();
            return View("SignUp", model);
        }

        public IActionResult Delete(int id)
        {
            _userRepo.Delete(id);
            _userRepo.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}
