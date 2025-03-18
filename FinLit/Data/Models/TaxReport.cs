using FinLit.Data.Interfaces;

namespace FinLit.Data.Models
{
    public class TaxReport : IReport
    {
        public int Id { get; set; }
        public required string ReportType { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TaxDue { get; set; } // налог к уплате (подоходный без фсзн и тд)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
