using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EShop.Web.Controllers
{
    public class MovieTicketsController : Controller
    {
        private readonly IMovieTicketService _movieTicketsService;
        private readonly ILogger<MovieTicketsController> _logger;

        public MovieTicketsController(ILogger<MovieTicketsController> logger, IMovieTicketService movieTicketsService)
        {
            _logger = logger;
            _movieTicketsService = movieTicketsService;
        }

        // GET: MovieTickets
        public IActionResult Index()
        {
            _logger.LogInformation("User Request -> Get All movie tickets!");
            return View(this._movieTicketsService.GetAllMovieTickets());
        }

        // GET: MovieTickets/Details/5
        public IActionResult Details(Guid? id)
        {
            _logger.LogInformation("User Request -> Get Details For MovieTicket");
            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._movieTicketsService.GetDetailsForMovieTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: MovieTickets/Create
        public IActionResult Create()
        {
            _logger.LogInformation("User Request -> Get create form for MovieTicket!");
            return View();
        }

        // POST: MovieTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieName,Genre,MovieDateTime,Price,MovieRating")] MovieTicket movieTicket)
        {
            _logger.LogInformation("User Request -> Inser MovieTicket in DataBase!");
            if (ModelState.IsValid)
            {
                movieTicket.Id = Guid.NewGuid();
                this._movieTicketsService.CreateNewMovieTicket(movieTicket);
                return RedirectToAction(nameof(Index));
            }
            return View(movieTicket);
        }

        // GET: MovieTickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            _logger.LogInformation("User Request -> Get edit form for MovieTicket!");
            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._movieTicketsService.GetDetailsForMovieTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: MovieTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,MovieName,Genre,MovieDateTime,Price,MovieRating")] MovieTicket movieTicket)
        {
            _logger.LogInformation("User Request -> Update MovieTicket in DataBase!");

            if (id != movieTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._movieTicketsService.UpdateExistingMovieTicket(movieTicket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieTicketExists(movieTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movieTicket);
        }

        // GET: movieTickets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            _logger.LogInformation("User Request -> Get delete form for MovieTicket!");

            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._movieTicketsService.GetDetailsForMovieTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: movieTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _logger.LogInformation("User Request -> Delete MovieTicket in DataBase!");

            this._movieTicketsService.DeleteMovieTicket(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddMovieTicketToCard(Guid id)
        {
            var result = this._movieTicketsService.GetShoppingCartInfo(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovieTicketToCard(AddToShoppingCardDto model)
        {

            _logger.LogInformation("User Request -> Add MovieTicket in ShoppingCart and save changes in database!");


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._movieTicketsService.AddToShoppingCart(model, userId);

            if(result)
            {
                return RedirectToAction("Index", "MovieTickets");
            }
            return View(model);
        }
        private bool MovieTicketExists(Guid id)
        {
            return this._movieTicketsService.GetDetailsForMovieTicket(id) != null;
        }
    }
}
