using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerApp.Models;

namespace TaskManagerApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly TaskManagerDbContext _context;


        public LoginController(TaskManagerDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create([Bind("Name, UserName,Password,IsAdmin")] ModelAdminLogin model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsAdmin == true)
                {
                    //admin login
                    if (_context.AdminDetails.Any(e => e.UserName == model.UserName && e.Password == model.Password))
                    {
                        //Redirect to employee module
                        return RedirectToAction("index", "EmployeeRegisters");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                        //redirect to login
                    }
                }
                else
                {
                    //employe login

                  
                    if (_context.EmployeeRegisters.Any(e => e.UserName == model.UserName && e.Password == model.Password))
                    {
                     
                        //redirect to employee task details

                        return RedirectToAction("index", "EmployeeTasks");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                        //redirect to login
                    }
                }

            }

            else
            {
                return View("index");
                //redirect to login
            }
                //_context.Add(modelEmployeeRegister);
                //await _context.SaveChangesAsync();
            }


        }

    } 

