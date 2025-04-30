using System.Net;

namespace PropertyPro.Frontend.Models.Response
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
    }
}
