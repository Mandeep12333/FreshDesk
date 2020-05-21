using FreshDesk.APIControllers;
using FreshDesk.Models;
using Microsoft.Extensions.Options;
using Xunit;

namespace FreshDesk.Unit.Tests
{
    public class ConversationAPIShould
    {
        public IOptions<FreshDeskModel> _freshDeskModel;
        public int successStatus = 200;

        public ConversationAPIShould()
        {
            var freskdesk = new FreshDeskModel
            {
                APIKey = "LC3d8WEIupV2KLs5fZZX",
                BaseURL = "https://rafadevsupport.freshdesk.com/api/v2/"
            };
            _freshDeskModel = Options.Create(freskdesk);
        }

        [Fact]
        public void Returnscreatenote()
        {
            var noteModel = new NoteModel
            {
                body = "Test Description",
                notify_emails = new string[1] { "test@test.com" },
                Private = true
            };

            int id = 20;

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.CreateNote(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        [Fact]
        public void Returnsupdateaconversation()
        {
            string body = "Test Description";

            int id = 20;

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.Updateaconversation(id, body);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        [Fact]
        public void Returnsdeleteaconversation()
        {
            int id = 20;   //Id need to be change every time

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.Deleteaconversation(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }
    }
}
