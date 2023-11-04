namespace GoBye.BLL.Dtos.ReportDtos
{
    public class ReportAddDto
    {
        public int ReservationNumber { get; set; }
        public string MessageTitle { get; set; } = string.Empty;
        public string MessageContent { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
