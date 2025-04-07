using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Responses
{
    public class ResponseModel<T>
    {
        // status
        public HttpStatusCode StatusCode { get; set; }
        public bool Status { get; set; }
        public string? Message { get; set; }

        /// Data and Errors
        public List<T> Data { get; set; }
        public List<string>? Errors { get; set; }

        // Constructor(s)
        public ResponseModel()
        {
            Status = true;
            StatusCode = HttpStatusCode.OK;
        }

        /// <summary>
        /// return response model with status code: OK,
        /// with/without message and retrieving data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public ResponseModel(List<T> data, string? message = null) : this()
        {
            Data = data;
            Message = message;
        }

        /// <summary>
        /// return response model with status code: OK,
        /// with message but without retrieving data.
        /// </summary>
        /// <param name="message"></param>
        public ResponseModel(string message) : this()
        {
            Message = message;
        }

        /// <summary>
        /// return response model 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="succeeded">the staus of process (true if success, otherwise false) </param>
        /// <param name="errors">Failer message if exist</param>
        public ResponseModel(string message, bool succeeded, List<string> errors = null)
        {
            StatusCode = succeeded ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            Status = succeeded;
            Message = message;
            Errors = errors;
        }
    }
}
