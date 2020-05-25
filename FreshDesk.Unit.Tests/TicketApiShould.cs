using FreshDesk.APIControllers;
using FreshDesk.Models;
using FreshDesk.Utilities;
using Microsoft.Extensions.Options;
using Xunit;

namespace FreshDesk.Unit.Tests
{
    public class TicketApiShould
    {
        public IOptions<FreshDeskModel> _freshDeskModel;
        private readonly ExceptionFilter _exceptionFilter;
        public int successStatus = 200;
        public int failureStatus = 400;

        public TicketApiShould()
        {
            var freskdesk = new FreshDeskModel
            {
                APIKey = "LC3d8WEIupV2KLs5fZZX",
                BaseURL = "https://rafadevsupport.freshdesk.com/api/v2/"
            };
            _freshDeskModel = Options.Create(freskdesk);
            _exceptionFilter = new ExceptionFilter();
        }

        /// <summary>
        /// Test the Create ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateTicketsSuccess()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test@test.com",
                priority = Enum.TicketPriority.High,
                status = Enum.TicketStatus.Open,
                subject = "test"
            };

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.CreateTickets(ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the Create ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateTicketsFailure()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test",
                priority = Enum.TicketPriority.High,
                status = Enum.TicketStatus.Open,
                subject = "test"
            };

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.CreateTickets(ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the view a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsViewTicketSuccess()
        {
            //Arrange
            long id = 50;

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.ViewTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the view a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsViewTicketFailure()
        {
            //Arrange
            long id = 0;

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.ViewTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the list of all tickets method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsListAllTickets()
        {
            //Arrange
            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

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
        public void ReturnsUpdateTicketSuccess()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test@test.com",
                priority = Enum.TicketPriority.High,
                status = Enum.TicketStatus.Open,
                subject = "test"
            };

            long id = 50;

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.UpdateTicket(id, ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the update a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsUpdateTicketFailure()
        {
            //Arrange
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test",
                priority = Enum.TicketPriority.High,
                status = Enum.TicketStatus.Open,
                subject = "test"
            };

            long id = 0;

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.UpdateTicket(id, ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the delete a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteTicketSuccess()
        {
            //Arrange
            long id = 51;  //Id need to be change every time

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.DeleteTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the delete a ticket method of the Ticket API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteTicketFailure()
        {
            //Arrange
            long id = 0;  //Id need to be change every time

            var controller = new TicketsApiController(_freshDeskModel, _exceptionFilter);

            // Act
            var result = controller.DeleteTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }
    }
}
