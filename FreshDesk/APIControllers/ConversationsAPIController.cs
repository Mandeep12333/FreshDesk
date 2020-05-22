using FreshDesk.Models;
using FreshDesk.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FreshDesk.APIControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsAPIController : ControllerBase
    {
        private readonly FreshDeskModel _freshDeskModel;
        private readonly ExceptionFilter _exceptionFilter;

        public ConversationsAPIController(IOptions<FreshDeskModel> freshDeskModel, ExceptionFilter exceptionFilter)
        {
            _freshDeskModel = freshDeskModel.Value;   //Get API Key and Base URL from the appsettings.json
            _exceptionFilter = exceptionFilter;
        }

        /// <summary>
        /// Create Note with these 1 parameters:
        /// 1.body Content of the note in HTML
        /// </summary>
        [HttpPost]
        [Route("CreateNote")]
        public IActionResult CreateNote(long ticket_id, NoteModel noteModel)
        {
            if(ModelState.IsValid && ticket_id != 0)
            {
                string apiPath = $"tickets/{ticket_id}/notes";
                string json = JsonConvert.SerializeObject(noteModel);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_freshDeskModel.BaseURL + apiPath);
                request.ContentType = "application/json";
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentLength = byteArray.Length;
                string authInfo = _freshDeskModel.APIKey + ":X";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                try
                {
                    WebResponse response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string Response = reader.ReadToEnd();
                    NotesModel notes = new NotesModel();
                    notes = JsonConvert.DeserializeObject<NotesModel>(Response);
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    var ex = (int)((HttpWebResponse)e.Response).StatusCode;
                    ExceptionModel exceptionModel = _exceptionFilter.ExceptionType(ex);
                    return BadRequest(exceptionModel);
                }
            }
            else if(ticket_id == 0)
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
                string apiPath = $"tickets/{id}/conversations";
                string responseBody = String.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_freshDeskModel.BaseURL + apiPath);
                request.ContentType = "application/json";
                request.Method = "GET";
                string authInfo = _freshDeskModel.APIKey + ":X";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        responseBody = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                    }
                    List<NotesModel> notes = new List<NotesModel>();
                    notes = JsonConvert.DeserializeObject<List<NotesModel>>(responseBody);
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    var ex = (int)((HttpWebResponse)e.Response).StatusCode;
                    ExceptionModel exceptionModel = _exceptionFilter.ExceptionType(ex);
                    return BadRequest(exceptionModel);
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
            if(ModelState.IsValid && id != 0)
            {
                string apiPath = $"conversations/{id}";
                string json = JsonConvert.SerializeObject(noteModel);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_freshDeskModel.BaseURL + apiPath);
                request.ContentType = "application/json";
                request.Method = "PUT";
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentLength = byteArray.Length;
                string authInfo = _freshDeskModel.APIKey + ":X";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                try
                {
                    WebResponse response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string Response = reader.ReadToEnd();
                    NotesModel notes = new NotesModel();
                    notes = JsonConvert.DeserializeObject<NotesModel>(Response);
                    return Ok(notes);
                }
                catch (WebException e)
                {
                    var ex = (int)((HttpWebResponse)e.Response).StatusCode;
                    ExceptionModel exceptionModel = _exceptionFilter.ExceptionType(ex);
                    return BadRequest(exceptionModel);
                }
            }
            else if(id == 0)
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
                string apiPath = $"conversations/{id}";
                string responseBody = String.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_freshDeskModel.BaseURL + apiPath);
                request.ContentType = "application/json";
                request.Method = "DELETE";
                string authInfo = _freshDeskModel.APIKey + ":X";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        responseBody = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                    }
                    return Ok("Deleted Successfully");
                }
                catch (WebException e)
                {
                    var ex = (int)((HttpWebResponse)e.Response).StatusCode;
                    ExceptionModel exceptionModel = _exceptionFilter.ExceptionType(ex);
                    return BadRequest(exceptionModel);
                }
            }
            else
            {
                return BadRequest("Enter Id");
            }
        }
    }
}