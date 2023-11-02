namespace GoBye.BLL.Dtos.ReportDtos
{
    public class ReportAddDto
    {
        public int ReservationNumber { get; set; }
        public string Message { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
