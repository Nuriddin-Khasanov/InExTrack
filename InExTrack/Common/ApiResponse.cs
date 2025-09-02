namespace InExTrack.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; } // Добавлен ? для поддержки null

        public ApiResponse(T? data, string message)
        {
            Success = true;
            Message = message;
            Data = data;
        }
        public ApiResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Data = default;
        }
    }
}
