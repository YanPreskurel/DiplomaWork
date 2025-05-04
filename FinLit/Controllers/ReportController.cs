using FinLit.Data.Interfaces;
using FinLit.Data.Models;
using FinLit.Services;
using FinLit.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinLit.Controllers
{
    public class ReportController : Controller
    {
        private readonly IIncomeReports incomeReportsRepository;
        private readonly IExpenseReports expenseReportsRepository;
        private readonly IForecastReports forecastReportsRepository;
        private readonly ReportService reportService;
        public ReportController(IIncomeReports incomeReportsRepository, IExpenseReports expenseReportsRepository, IForecastReports forecastReportsRepository, ReportService reportService)
        {             
            this.incomeReportsRepository = incomeReportsRepository;      
            this.expenseReportsRepository = expenseReportsRepository;      
            this.forecastReportsRepository = forecastReportsRepository;      
            this.reportService = reportService;      
        }

        [HttpGet]
        public async Task<IActionResult> ReportView()
        {
            var selectedAccountId = HttpContext.Session.GetInt32("SelectedAccountId") ?? 1; // добавить строку что либо выбранный акканут либо дефолтный потом в дальнейшем во вкладке персонализации

            var model = await reportService.GetReportViewModelAsync(selectedAccountId);

            return View(model);
        }
    }
}
