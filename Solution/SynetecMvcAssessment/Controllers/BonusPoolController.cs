using SynetecMvcAssessment.Application.Data;
using SynetecMvcAssessment.Application.Models;
using SynetecMvcAssessment.Application.Services.Abstract;
using System.Linq;
using System.Web.Mvc;
using SynetecMvcAssessment.Application.ModelBuilders.Abstract;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolModelBuilder _bonusPoolModelBuilder;
        private readonly IEmployeeService _employeeService;

        public BonusPoolController(
            IBonusPoolModelBuilder bonusPoolModelBuilder,
            IEmployeeService employeeService)
        {
            _bonusPoolModelBuilder = bonusPoolModelBuilder;
            _employeeService = employeeService;
        }

        public BonusPoolController()
        {   
        }

        private MvcInterviewV3Entities1 db = new MvcInterviewV3Entities1();

        // GET: BonusPool
        public ActionResult Index()
        {
            //I don't think there is a need for the VMB
            //var model = _bonusPoolModelBuilder.Build();
            //Call off to the service
            //var model = _employeeService.GetAllEmployees();

            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();

            model.AllEmployees = db.HrEmployees.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            /*I don't think there is a need for the VMB, this will need to change as we won't be
              showing the same VMB as the Index page if we decided to take the VMB route.*/
            //var viewModel = _bonusPoolModelBuilder.Build();
            //Call off to the service, which calls off the DAL
            //var result = _employeeService.GetBonus(model);

            var selectedEmployeeId = model.SelectedEmployeeId;
            var totalBonusPool = model.BonusPoolAmount;

            //load the details of the selected employee using the ID
            var hrEmployee = db.HrEmployees.FirstOrDefault(item => item.ID == selectedEmployeeId);

            var employeeSalary = hrEmployee.Salary;

            //get the total salary budget for the company
            var totalSalary = (int)db.HrEmployees.Sum(item => item.Salary);

            //calculate the bonus allocation for the employee
            var bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            var bonusAllocation = (int)(bonusPercentage * totalBonusPool);

            var result = new BonusPoolCalculatorResultModel
            {
                HrEmployee = hrEmployee,
                BonusPoolAllocation = bonusAllocation
            };

            return View(result);
        }
    }
}