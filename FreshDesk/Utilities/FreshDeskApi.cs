using FreshDesk.Models;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace FreshDesk.Utilities
{
    public class FreshDeskApi
    {
        private readonly FreshDeskModel _freshDeskModel;
        private readonly ExceptionFilter _exceptionFilter;
        public FreshDeskApi(IOptions<FreshDeskModel> freshDeskModel, ExceptionFilter exceptionFilter)
        {
            _freshDeskModel = freshDeskModel.Value;  //Get API Key and Base URL from the appsettings.json
            _exceptionFilter = exceptionFilter;
        }

        public string FreshDesk(string apiPath, string json, string methodType)
        {
            string responseBody = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_freshDeskModel.BaseURL + apiPath);
            request.ContentType = "application/json";
            request.Method = methodType;
            string authInfo = _freshDeskModel.APIKey + ":X";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            if (methodType == "POST" || methodType == "PUT")
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseBody = reader.ReadToEnd();
                return responseBody;
            }
            else if (methodType == "GET" || methodType == "DELETE")
            {
                using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseBody = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                return responseBody;
            }
            else
            {
                return responseBody;
            }
        }

        public ExceptionModel Exception(WebException e)
        {
            var ex = (int)((HttpWebResponse)e.Response).StatusCode;
            ExceptionModel exceptionModel = _exceptionFilter.ExceptionType(ex);
            return exceptionModel;
        }
    }
}
