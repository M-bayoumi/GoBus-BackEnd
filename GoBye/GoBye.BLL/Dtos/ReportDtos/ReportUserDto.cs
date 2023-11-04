namespace GoBye.BLL.Dtos.ReportDtos
{
    public class ReportUserDto
    {
        public int Id { get; set; }
        public int ReservationNumber { get; set; }
        public string MessageTitle { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
    }
}
