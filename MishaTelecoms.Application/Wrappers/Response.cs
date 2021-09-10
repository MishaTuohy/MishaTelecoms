using System.Collections.Generic;

namespace MishaTelecoms.Application.Wrappers
{
    // Response Wrapper for queries
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response() { }

        // Successfull reponse
        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        // Failed response
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}
