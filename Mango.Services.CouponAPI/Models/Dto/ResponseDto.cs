namespace Mango.Services.CouponAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
    }

    public class Response
    {
        public object? Result { get; set; }
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
