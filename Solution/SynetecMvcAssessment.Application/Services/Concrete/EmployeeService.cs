using SynetecMvcAssessment.Application.DAL.Abstract;
using SynetecMvcAssessment.Application.Models;
using SynetecMvcAssessment.Application.Services.Abstract;

namespace SynetecMvcAssessment.Application.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public BonusPoolCalculatorModel GetAllEmployees()
        {
            return _repository.GetAllEmployees();
        }

        public BonusPoolCalculatorResultModel GetBonus(BonusPoolCalculatorModel model)
        {
            var selectedEmployeeId = model.SelectedEmployeeId;
            var totalBonusPool = model.BonusPoolAmount;

            var selectedEmployee = _repository.GetSelectedEmployeeById(selectedEmployeeId);

            var employeeSalary = selectedEmployee.Salary;

            var totalSalary = _repository.GetTotalSalaryBudgetForCompany();
            
            var bonusPercentage = (decimal)employeeSalary / (decimal)totalSalary;
            var bonusAllocation = (int)(bonusPercentage * totalBonusPool);

            return new BonusPoolCalculatorResultModel
            {
                HrEmployee = selectedEmployee,
                BonusPoolAllocation = bonusAllocation
            };
        }
    }
}
