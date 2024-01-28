using System.Collections;

namespace ErrorHandling.API.Models
{
    internal class ExceptionResultDto
    {
        public ExceptionResultDto(string details, IDictionary data, string[] errors)
        {
            Details = details;
            Data = data;
            Errors = errors;
        }

        public IDictionary Data { get; }
        public string Details { get; }
        public string[] Errors { get; set; }
        public string Exception { get; set; }
    }
}