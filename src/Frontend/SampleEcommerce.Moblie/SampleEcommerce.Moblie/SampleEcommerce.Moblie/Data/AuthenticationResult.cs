namespace SampleEcommerce.Moblie.Data
{
    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Customer Customer { get; set; }
    }
}
