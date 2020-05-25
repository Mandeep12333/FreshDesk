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
    public class TicketsApiController : ControllerBase
    {
        private readonly FreshDeskApi _freshDeskApi;

        public TicketsApiController(FreshDeskApi freshDeskApi)
        {
            _freshDeskApi = freshDeskApi;
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
            if (ModelState.IsValid)
            {
                try
                {
                    TicketsModel Tickets = JsonConvert.DeserializeObject<TicketsModel>
                        (_freshDeskApi.FreshDesk("tickets", JsonConvert.SerializeObject(ticketModel), "POST"));
                    return Ok(Tickets);
                }
                catch (WebException e)
                {
                    return BadRequest(_freshDeskApi.Exception(e));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// View a Ticket on the basis of Id
        /// </summary>
        [HttpGet]
        [Route("ViewTicket")]
        public IActionResult ViewTicket(long id)
        {
            if (id != 0)
            {
                try
                {
                    TicketsModel Tickets = JsonConvert.DeserializeObject<TicketsModel>
                        (_freshDeskApi.FreshDesk($"tickets/{id}", null, "GET"));
                    return Ok(Tickets);
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
        /// Get All Tickets
        /// </summary>
        [HttpGet]
        [Route("ListAllTickets")]
        public IActionResult ListAllTickets()
        {
            try
            {
                List<TicketsModel> TicketsList = JsonConvert.DeserializeObject<List<TicketsModel>>
                    (_freshDeskApi.FreshDesk("tickets", null, "GET"));
                return Ok(TicketsList);
            }
            catch (WebException e)
            {
                return BadRequest(_freshDeskApi.Exception(e));
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
        [Route("UpdateTicket")]
        public IActionResult UpdateTicket(long id, TicketModel ticketModel)
        {
            if (ModelState.IsValid && id != 0)
            {
                try
                {
                    TicketsModel Tickets = JsonConvert.DeserializeObject<TicketsModel>
                        (_freshDeskApi.FreshDesk($"tickets/{id}", JsonConvert.SerializeObject(ticketModel), "PUT"));
                    return Ok(Tickets);
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
        /// Delete a Ticket on the basis of Id
        /// </summary>
        [HttpDelete]
        [Route("DeleteTicket")]
        public IActionResult DeleteTicket(long id)
        {
            if (id != 0)
            {
                try
                {
                    _freshDeskApi.FreshDesk($"tickets/{id}", null, "DELETE");
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