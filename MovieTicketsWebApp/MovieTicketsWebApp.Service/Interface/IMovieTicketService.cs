using EShop.Domain.DomainModels;
using EShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Service.Interface
{
    public interface IMovieTicketService
    {
        List<MovieTicket> GetAllMovieTickets();
        MovieTicket GetDetailsForMovieTicket(Guid? id);
        void CreateNewMovieTicket(MovieTicket p);
        void UpdateExistingMovieTicket(MovieTicket p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteMovieTicket(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}
