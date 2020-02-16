using System;

namespace ApiClient.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Content { get; set; }
        
        public Exception Exception { get; set; }

        public ApiResponse(T content)
        {
            Content = content;
            IsSuccess = true;
        }

        public ApiResponse(Exception e)
        {
            Exception = e;
            IsSuccess = false;
        }
    }
}