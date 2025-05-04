using FinLit.Data;
using FinLit.Data.Models;
using FinLit.Data.Models.Interfaces;
using FinLit.Data.Repository;
using FinLit.Services;

namespace FinLit.ViewModels
{
    public class AccountMoneyTrackingViewModel
    {
        public IEnumerable<Account>? Accounts { get; set; }
        public IEnumerable<MoneyTracking>? MoneyTrackings { get; set; }
    }
}
