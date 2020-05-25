using FreshDesk.APIControllers;
using FreshDesk.Models;
using FreshDesk.Utilities;
using Microsoft.Extensions.Options;
using Xunit;

namespace FreshDesk.Unit.Tests
{
    public class ConversationApiShould
    {
        public IOptions<FreshDeskModel> _freshDeskModel;
        private readonly ExceptionFilter _exceptionFilter;
        private readonly FreshDeskApi _freshDeskApi;
        public int successStatus = 200;
        public int failureStatus = 400;

        public ConversationApiShould()
        {
            var freskdesk = new FreshDeskModel
            {
                APIKey = "LC3d8WEIupV2KLs5fZZX",
                BaseURL = "https://rafadevsupport.freshdesk.com/api/v2/"
            };
            _freshDeskModel = Options.Create(freskdesk);
            _exceptionFilter = new ExceptionFilter();
            _freshDeskApi = new FreshDeskApi(_freshDeskModel, _exceptionFilter);
        }

        /// <summary>
        /// Test the Create note method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateNoteSuccess()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = "Test Description"
            };

            long id = 50;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.CreateNote(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the Create note method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsCreateNoteFailure()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = null
            };

            long id = 50;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.CreateNote(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the list all ticket notes method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsListAllTicketNotesSuccess()
        {
            //Arrange
            long id = 50;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.ListAllTicketNotes(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the list all ticket notes method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsListAllTicketNotesFailure()
        {
            //Arrange
            long id = 0;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.ListAllTicketNotes(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the update conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsUpdateConversationSuccess()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = "Test Description"
            };

            long id = 65000261625;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.UpdateConversation(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the update conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsUpdateConversationFailure()
        {
            //Arrange
            var noteModel = new NoteModel
            {
                body = null
            };

            long id = 65000261625;

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.UpdateConversation(id, noteModel);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }

        /// <summary>
        /// Test the delete conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteConversationSuccess()
        {
            //Arrange
            long id = 65000261613;   //Id need to be change every time

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.DeleteConversation(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(successStatus, statusCode);
        }

        /// <summary>
        /// Test the delete conversation method of the Conversation API Controller
        /// </summary>
        [Fact]
        public void ReturnsDeleteConversationFailure()
        {
            //Arrange
            long id = 6500;   //Id need to be change every time

            var controller = new ConversationsApiController(_freshDeskApi);

            // Act
            var result = controller.DeleteConversation(id);
            var statusCode = (((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);

            //Assert
            Assert.Equal(failureStatus, statusCode);
        }
    }
}
