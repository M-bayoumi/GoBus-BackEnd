namespace GoBye.BLL.Dtos.ClassImageDto
{
    public class ClassImageReadDto
    {
        public int Id { get; set; }
        public int BusClassId { get; set; }
        public string ImageURL { get; set; } = string.Empty;
    }
}
