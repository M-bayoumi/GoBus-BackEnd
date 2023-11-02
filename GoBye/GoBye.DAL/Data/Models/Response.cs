namespace GoBye.DAL.Data.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public object? Data { get; set; } = new object();
        public object? Messages { get; set; } = new object();
    }
}
