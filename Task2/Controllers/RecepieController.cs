using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task2.Data;
using Task2.Models;
using Task2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Task2.Controllers
{
    public class RecepieController : Controller
    {

        ApplicationDbContext db;
        UserManager<ApplicationUser> _userManager;
        public RecepieController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            db = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateRecepie()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateRecepie(Recepie recepie)
        {
            recepie.DateOfLastUpdate = DateTime.Now;
            recepie.RecepieAuthor = await _userManager.GetUserAsync(User);
            db.RecepieCollection.Add(recepie);
            db.SaveChanges();
            return RedirectToAction("RecepieCollection");
        }

        [HttpGet]
        public IActionResult ViewRecepie(int id)
        {
            var recepie = db.RecepieCollection.FirstOrDefault(m => m.Id == id);
            var comments = db.Comments.Where(c => c.Recepie == recepie);
            comments.ToList();
            return View(recepie);
        }

        [HttpPost]
        public IActionResult EditRecepie(int id)
        {
            var recepie = db.RecepieCollection.FirstOrDefault(m => m.Id == id);
            return View(recepie);
        }

        public async Task<IActionResult> RecepieCollection(int page = 1)
        {
            IQueryable<Recepie> recepie = db.RecepieCollection;
            recepie = recepie.OrderByDescending(s => s.DateOfLastUpdate);
            int pageSize = 5;
            var count = await recepie.CountAsync();
            var items = await recepie.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            PageIndexViewModel viewModel = new PageIndexViewModel
            {
                PageViewModel = pageViewModel,
                EnumRecepie = items
            };
            return View(viewModel);
        }

        public async Task<IActionResult>  RecepieManagement(int page = 1)
        {
            IQueryable<Recepie> recepie = db.RecepieCollection;
            recepie = recepie.OrderByDescending(s => s.DateOfLastUpdate);
            int pageSize = 10;
            var count = await recepie.CountAsync();
            var items = await recepie.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            PageIndexViewModel viewModel = new PageIndexViewModel
            {
                PageViewModel = pageViewModel,
                EnumRecepie = items
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task <IActionResult> DeleteRecepie(int id)
        {
            var recepie = await db.RecepieCollection.SingleOrDefaultAsync(m => m.Id == id);
            db.RecepieCollection.Remove(recepie);
            db.SaveChanges();
            return RedirectToAction("RecepieCollection");
        }

        [HttpPost]
        public IActionResult ApplyRecepieEditing(Recepie recepie)
        {
            recepie.DateOfLastUpdate = DateTime.Now;
            db.RecepieCollection.Update(recepie);
            db.SaveChanges();
            return RedirectToAction("RecepieManagement");
        }

        [Authorize]
        public async Task<IActionResult> CreateComment(int id, string text)
        {
            var commentAuthor = await _userManager.GetUserAsync(User);
            var commentedRecepie = db.RecepieCollection.SingleOrDefault(r => r.Id == id);

            var comment = new Comment
            {
                Author = commentAuthor,
                Recepie = commentedRecepie,
                CreatorName = _userManager.GetUserName(User),
                Text = text,
                CreationTime = DateTime.Now
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("ViewRecepie", new { id = id });
        }



    }
}