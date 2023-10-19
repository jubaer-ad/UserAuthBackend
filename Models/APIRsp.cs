namespace backend.Models
{
    public class APIRsp
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public dynamic? Data { get; set; }
        public int StatusCode { get; set; }
    }
}
