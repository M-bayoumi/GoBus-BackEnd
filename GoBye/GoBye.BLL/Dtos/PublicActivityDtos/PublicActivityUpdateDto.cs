namespace GoBye.BLL.Dtos.PublicActivityDtos
{
    public class PublicActivityUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DestinationID { get; set; }
    }
}
