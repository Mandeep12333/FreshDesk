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

        /// <summary>
        /// Test the Create note method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateNote()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = "Test Description"
            };

            long id = 38;

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.CreateNote(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the list all ticket notes method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsListAllTicketNotes()
        {
            //Arrange
            long id = 38;

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.ListAllTicketNotes(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the update conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsUpdateConversation()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = "Test Description"
            };

            long id = 65000213246;

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.UpdateConversation(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the delete conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteConversation()
        {
            //Arrange
            long id = 65000213324;   //Id need to be change every time

            var controller = new ConversationsAPIController(_freshDeskModel);

            // Act
            var result = controller.DeleteConversation(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }
    }
}
