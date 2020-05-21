using FreshDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
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

        public ConversationsAPIController(IOptions<FreshDeskModel> freshDeskModel)
        {
            _freshDeskModel = freshDeskModel.Value;   //Get API Key and Base URL from the appsettings.json
        }

        /// <summary>
        /// Create Note with these 3 parameters:
        /// 1.body Content of the note in HTML
        /// 2.incoming The default value is false
        /// 3.Private The default value is true
        /// </summary>
        [HttpPost]
        [Route("CreateNote")]
        public IActionResult CreateNote(int ticket_id, NoteModel noteModel)
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
                return Ok(Response);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        /// <summary>
        /// Update a conversation's body parameters on the basis of Id:
        /// body Content of the note in HTML
        /// </summary>
        [HttpPut]
        [Route("Updateaconversation")]
        public IActionResult Updateaconversation(int id, string body)
        {
            string apiPath = $"conversations/{id}";
            string json = JsonConvert.SerializeObject(body);
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
                return Ok(Response);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        /// <summary>
        /// Delete a conversation on the basis of Id
        /// </summary>
        [HttpDelete]
        [Route("Deleteaconversation")]
        public IActionResult Deleteaconversation(int id)
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
                return Ok(responseBody);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}