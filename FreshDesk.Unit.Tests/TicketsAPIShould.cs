﻿using FreshDesk.APIControllers;
using FreshDesk.Models;
using Microsoft.Extensions.Options;
using Xunit;

namespace FreshDesk.Unit.Tests
{
    public class TicketsAPIShould
    {
        public IOptions<FreshDeskModel> _freshDeskModel;
        public int successStatus = 200;

        public TicketsAPIShould()
        {
            var freskdesk = new FreshDeskModel
            {
                APIKey = "LC3d8WEIupV2KLs5fZZX",
                BaseURL = "https://rafadevsupport.freshdesk.com/api/v2/"
            };
            _freshDeskModel = Options.Create(freskdesk);
        }

        /// <summary>
        /// Test the Create ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateTickets()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test@test.com",
                priority = 1,
                status = 2,
                subject = "test"
            };

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.CreateTickets(ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the view a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsViewaTicket()
        {
            //Arrange
            long id = 20;

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.ViewTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the list of all tickets method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsListAllTickets()
        {
            //Arrange
            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.ListAllTickets();
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the update a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsUpdateTicket()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test@test.com",
                priority = 1,
                status = 2,
                subject = "test"
            };

            long id = 20;

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.UpdateTicket(id, ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the delete a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteTicket()
        {
            //Arrange
            long id = 25;  //Id need to be change every time

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.DeleteTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }
    }
}
