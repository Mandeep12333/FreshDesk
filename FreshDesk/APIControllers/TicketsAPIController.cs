using FreshDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
    public class TicketsAPIController : ControllerBase
    {
        private readonly FreshDeskModel _freshDeskModel;

        public TicketsAPIController(IOptions<FreshDeskModel> freshDeskModel)
        {
            _freshDeskModel = freshDeskModel.Value;  //Get API Key and Base URL from the appsettings.json
        }

        /// <summary>
        /// Create Tickets with these 5 parameters:
        /// 1.email
        /// 2.subject
        /// 3.status
        /// 4.priority
        /// 5.description
        /// </summary>
        [HttpPost]
        [Route("CreateTickets")]
        public IActionResult CreateTickets(TicketModel ticketModel)
        {
            string apiPath = "tickets";
            string json = JsonConvert.SerializeObject(ticketModel);
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
                TicketsModel Tickets = new TicketsModel();
                Tickets = JsonConvert.DeserializeObject<TicketsModel>(Response);
                return Ok(Tickets);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// View a Ticket on the basis of Id
        /// </summary>
        [HttpGet]
        [Route("ViewaTicket")]
        public IActionResult ViewaTicket(long id)
        {
            string apiPath = $"tickets/{id}";
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
                TicketsModel Tickets = new TicketsModel();
                Tickets = JsonConvert.DeserializeObject<TicketsModel>(responseBody);
                return Ok(Tickets);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get All Tickets
        /// </summary>
        [HttpGet]
        [Route("ListAllTickets")]
        public IActionResult ListAllTickets()
        {
            string apiPath = "tickets";
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
                List<TicketsModel> TicketsList = new List<TicketsModel>();
                TicketsList = JsonConvert.DeserializeObject<List<TicketsModel>>(responseBody);
                return Ok(TicketsList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update a Tickets with these 5 parameters on the basis of Id:
        /// 1.email
        /// 2.subject
        /// 3.status
        /// 4.priority
        /// 5.description
        /// </summary>
        [HttpPut]
        [Route("UpdateaTicket")]
        public IActionResult UpdateaTicket(long id, TicketModel ticketModel)
        {
            string apiPath = $"tickets/{id}";
            string json = JsonConvert.SerializeObject(ticketModel);
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
                TicketsModel Tickets = new TicketsModel();
                Tickets = JsonConvert.DeserializeObject<TicketsModel>(Response);
                return Ok(Tickets);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete a Ticket on the basis of Id
        /// </summary>
        [HttpDelete]
        [Route("DeleteaTicket")]
        public IActionResult DeleteaTicket(long id)
        {
            string apiPath = $"tickets/{id}";
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}