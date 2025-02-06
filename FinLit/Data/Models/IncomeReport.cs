using FinLit.Data.Interfaces;

namespace FinLit.Data.Models
{
    public class IncomeReport : IReport
    {
        public int Id { get; set; }
        public decimal TotalIncomes { get; set; }
        public required string ReportType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
