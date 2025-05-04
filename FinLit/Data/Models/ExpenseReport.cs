using FinLit.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinLit.ViewModels;

namespace FinLit.Data.Models
{
    public class ExpenseReport : IReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalExpenses { get; set; }
        public required string ReportType { get; set; } // day month year period
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
