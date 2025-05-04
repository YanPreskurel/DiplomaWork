using FinLit.Data.Enums;
using FinLit.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FinLit.ViewModels
{
    public class DebtTrackerFormViewModel
    {
        public int Id { get; set; }

        public string? DebtType { get; set; } // Incoming or Outgoing

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите сумму больше 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Тип валюты обязательно")]
        public CurrencyType? Currency { get; set; }

        [Required(ErrorMessage = "Имя должника обязательно")]
        public string? Debtor { get; set; } // имя должника
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } = false;

        public IEnumerable<DebtTracker> DebtTrackers { get; set; } = new List<DebtTracker>();
    }
}

