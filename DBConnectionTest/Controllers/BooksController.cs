using System;
using System.Collections.Generic;
using DBConnectionTest.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DBConnectionTest.Data;

namespace DBConnectionTest.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _config;

        public BooksController(AppDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        // GET: Papers
        public IActionResult Index()
        {
            var appDBContext = _context.Books.Include(b => b.Author);
            return View(appDBContext);
        }
    }
}
