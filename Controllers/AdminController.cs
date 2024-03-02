using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBuilder.Models;
using WebsiteBuilder.ViewModels;

namespace WebsiteBuilder.Controllers
{


    [Authorize(Policy = "EmailPolicy")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var websiteViewModel = new List<WebsiteNUserViewModel>();
            var website = await _context.Websites.ToListAsync();

            var viewModel = new WebsiteNUserViewModel
            {
                User = users,
                Websites = website
            };

            return View(viewModel);
        }

        // GET: /Product/Create

        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            var websiteViewModel = new List<WebsiteNUserViewModel>();
            var website = await _context.Websites.ToListAsync();

            var viewModel = new WebsiteNUserViewModel
            {
                User = users,
                Websites = website
            };

            return View(viewModel);
        }
        


        // GET: /Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Websites.FirstOrDefaultAsync(m => m.WebsiteId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Websites.FindAsync(id);
            _context.Websites.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Websites.Any(e => e.WebsiteId == id);
        }


    }
  }
