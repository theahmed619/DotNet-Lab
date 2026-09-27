using FirstMVCProject.Data;
using FirstMVCProject.Dto;
using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace FirstMVCProject.Controllers


{
    public class AuthController(AppDbContext _context) : Controller
    {

        //private readonly AppDbContext _context;
        //public AuthController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUser(UserDto dto)
        {
            if (dto == null)
            {
                ViewBag.Message = "Please provide email and password";
                return View("Register");

            }
            if (dto.Email == null || dto.Password == null)
            {
                ViewBag.Message = "Email and password are required.";
                return View("Register");
            }

            var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (data != null)
            {
                ViewBag.Message = "Email already exists.";
                return View("Register");
            }

            _context.Users.Add(new User
            {
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        
        public async Task<IActionResult> LoginUser(UserDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
            {
                ViewBag.Message = "Email and password are required.";
                return View("Login");
            }

            
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            
            if (existingUser == null)
            {
                ViewBag.Message = "Email does not exist.";
                return View("Login");
            }

            
            if (existingUser.Password != dto.Password)
            {
                ViewBag.Message = "Incorrect password.";
                return View("Login");
            }

            return RedirectToAction("Index", "Dashboard");
        }





    }
}
