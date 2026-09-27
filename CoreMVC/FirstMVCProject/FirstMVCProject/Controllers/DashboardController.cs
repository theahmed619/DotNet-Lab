using FirstMVCProject.Data;
using FirstMVCProject.Dto;
using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Controllers
{
    public class DashboardController (AppDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            var list = _context.Employees.Select(x => new EmployeeDto
            {
                EmployeeName = x.EmployeeName,
                Department = x.Department,
                Email = x.Email,
                Designation = x.Designation,
                Id = x.Id
            }).ToList();
            return View(list);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult RedirectToEmployeeForm()
        {
            return RedirectToAction("AddEmployee");
        }

        public async Task<IActionResult> AddEmployeeDetail(EmployeeDto dto)
        {
           
            if (string.IsNullOrWhiteSpace(dto.EmployeeName) ||
                string.IsNullOrWhiteSpace(dto.Department) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Designation))
            {
                ViewBag.Message = "Please fill all the details in the form.";
                return View("AddEmployee");
            }

            var isexist = await _context.Employees.AnyAsync(e => e.Email == dto.Email);
            if (isexist)
            {
                ViewBag.Message = "Employee with the same email already exists.";
                return View("AddEmployee");
            }

            _context.Employees.Add(new Employee
            {
                EmployeeName = dto.EmployeeName,
                Department = dto.Department,
                Email = dto.Email,
                Designation = dto.Designation
            });

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

         
            if (data != null)
            {
                _context.Employees.Remove(data);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(new EmployeeDto
            {
                Id = data.Id,
                EmployeeName = data.EmployeeName,
                Department = data.Department,
                Email = data.Email,
                Designation = data.Designation
            });
        }

        public async Task<IActionResult> UpdateEmployeeDetail(EmployeeDto dto)
        {
            if (dto == null)
            {
                ViewBag.Message = "Please Fill All the Details in the form";
                return View("UpdateEmployee", dto);
            }

          
            var data = await _context.Employees.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (data == null)
            {
                return NotFound();
            }

            data.Email = dto.Email;
            data.EmployeeName = dto.EmployeeName;
            data.Designation = dto.Designation;
            data.Department = dto.Department;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
