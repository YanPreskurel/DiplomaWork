namespace FinLit.Data.Interfaces
{
    public interface IReport
    {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
