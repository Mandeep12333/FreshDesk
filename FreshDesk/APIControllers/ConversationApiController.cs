using FreshDesk.Models;
using FreshDesk.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace FreshDesk.APIControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsApiController : ControllerBase
    {
        private readonly FreshDeskApi _freshDeskApi;

        public ConversationsApiController(FreshDeskApi freshDeskApi)
        {
            _freshDeskApi = freshDeskApi;
        }

        /// <summary>
        /// Create Note with these 1 parameters:
        /// 1.body Content of the note in HTML
        /// </summary>
        [HttpPost]
        [Route("CreateNote")]
        public IActionResult CreateNote(long ticket_id, NoteModel noteModel)
        {
            if (ModelState.IsValid && ticket_id != 0)
            {
                try
                {
                    NotesModel notes = JsonConvert.DeserializeObject<NotesModel>
                        (_freshDeskApi.FreshDesk($"tickets/{ticket_id}/notes", JsonConvert.SerializeObject(noteModel), "POST"));
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    return BadRequest(_freshDeskApi.Exception(e));
                }
            }
            else if (ticket_id == 0)
            {
                return BadRequest("Enter Ticket Id");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// List all Ticket Notes on the basis of ticket id
        /// </summary>
        [HttpGet]
        [Route("ListAllTicketNotes")]
        public IActionResult ListAllTicketNotes(long id)
        {
            if (id != 0)
            {
                try
                {
                    List<NotesModel> notes = JsonConvert.DeserializeObject<List<NotesModel>>
                        (_freshDeskApi.FreshDesk($"tickets/{id}/conversations", null, "GET"));
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    return BadRequest(_freshDeskApi.Exception(e));
                }
            }
            else
            {
                return BadRequest("Enter Id");
            }
        }

        /// <summary>
        /// Update a conversation's body parameters on the basis of Id
        /// </summary>
        [HttpPut]
        [Route("UpdateConversation")]
        public IActionResult UpdateConversation(long id, NoteModel noteModel)
        {
            if (ModelState.IsValid && id != 0)
            {
                try
                {
                    NotesModel notes = JsonConvert.DeserializeObject<NotesModel>
                        (_freshDeskApi.FreshDesk($"conversations/{id}", JsonConvert.SerializeObject(noteModel), "PUT"));
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    return BadRequest(_freshDeskApi.Exception(e));
                }
            }
            else if (id == 0)
            {
                return BadRequest("Enter Id");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Delete a conversation on the basis of Id
        /// </summary>
        [HttpDelete]
        [Route("DeleteConversation")]
        public IActionResult DeleteConversation(long id)
        {
            if (id != 0)
            {
                try
                {
                    _freshDeskApi.FreshDesk($"conversations/{id}", null, "DELETE");
                    return Ok("Deleted Successfully");
                }
                catch (WebException e)
                {
                    return BadRequest(_freshDeskApi.Exception(e));
                }
            }
            else
            {
                return BadRequest("Enter Id");
            }
        }
    }
}