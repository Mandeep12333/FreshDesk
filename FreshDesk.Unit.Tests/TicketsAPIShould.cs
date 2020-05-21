using FreshDesk.APIControllers;
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

        [Fact]
        public void Returnscreatetickets()
        {
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

        [Fact]
        public void Returnsviewaticket()
        {
            int id = 20;

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.ViewaTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        [Fact]
        public void Returnslistalltickets()
        {
            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.ListAllTickets();
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        [Fact]
        public void Returnsupdateaticket()
        {
            var ticketModel = new TicketModel
            {
                description = "Test Description",
                email = "test@test.com",
                priority = 1,
                status = 2,
                subject = "test"
            };

            int id = 20;

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.UpdateaTicket(id, ticketModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        [Fact]
        public void Returnsdeleteaticket()
        {
            int id = 25;  //Id need to be change every time

            var controller = new TicketsAPIController(_freshDeskModel);

            // Act
            var result = controller.DeleteaTicket(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }
    }
}
