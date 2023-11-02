namespace GoBye.DAL.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
