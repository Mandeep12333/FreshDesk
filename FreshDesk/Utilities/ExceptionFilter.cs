using FreshDesk.Models;
using System;

namespace FreshDesk.Utilities
{
    public class ExceptionFilter
    {
        public ExceptionFilter()
        {

        }
        public ExceptionModel ExceptionType(int exceptionCode)
        {
            ExceptionModel exceptionModel = new ExceptionModel();
            try
            {
                exceptionModel.ExceptionCode = exceptionCode;
                switch (exceptionCode)
                {
                    case 400:
                        exceptionModel.Text = "Client or Validation Error";
                        exceptionModel.Description = "The request body/query string is not in the correct format.";
                        break;
                    case 401:
                        exceptionModel.Text = "Authentication Failure";
                        exceptionModel.Description = "Indicates that the Authorization header is either missing or incorrect.";
                        break;
                    case 403:
                        exceptionModel.Text = "Access Denied";
                        exceptionModel.Description = "This indicates that the agent whose credentials were used in making this request was not authorized to perform this API call. It could be that this API call requires admin level credentials or perhaps the Freshdesk portal doesn't have the corresponding feature enabled. It could also indicate that the user has reached the maximum number of failed login attempts or that the account has reached the maximum number of agents";
                        break;
                    case 404:
                        exceptionModel.Text = "Requested Resource not Found";
                        exceptionModel.Description = "This status code is returned when the request contains invalid ID/Freshdesk domain in the URL or an invalid URL itself. For example, an API call to retrieve a ticket with an invalid ID will return a HTTP 404 status code to let you know that no such ticket exists.";
                        break;
                    case 405:
                        exceptionModel.Text = "Method not allowed";
                        exceptionModel.Description = "This API request used the wrong HTTP verb/method.";
                        break;
                    case 406:
                        exceptionModel.Text = "Unsupported Accept Header";
                        exceptionModel.Description = "Only application/json and */* are supported.When uploading files multipart/form-data is supported.";
                        break;
                    case 409:
                        exceptionModel.Text = "Inconsistent/Conflicting State";
                        exceptionModel.Description = "The resource that is being created/updated is in an inconsistent or conflicting state.";
                        break;
                    case 415:
                        exceptionModel.Text = "Unsupported Content-type";
                        exceptionModel.Description = "Content type application/xml is not supported. Only application/json is supported.";
                        break;
                    case 429:
                        exceptionModel.Text = "Rate Limit Exceeded";
                        exceptionModel.Description = "The API rate limit allotted for your Freshdesk domain has been exhausted.";
                        break;
                    case 500:
                        exceptionModel.Text = "Unexpected Server Error";
                        exceptionModel.Description = "Phew!! You can't do anything more here. This indicates an error at Freshdesk's side. Please email us your API script along with the response headers. We will reach you out to you and fix this ASAP.";
                        break;
                    default:
                        break;
                }
                return exceptionModel;
            }
            catch (Exception e)
            {
                exceptionModel.Description = e.Message;
                return exceptionModel;
            }
        }
    }
}
