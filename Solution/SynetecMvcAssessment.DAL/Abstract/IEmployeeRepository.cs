using SynetecMvcAssessment.Application.Data;
using SynetecMvcAssessment.Application.Models;

namespace SynetecMvcAssessment.DAL.Abstract
{
    public interface IEmployeeRepository
    {
        BonusPoolCalculatorModel GetAllEmployees();
        HrEmployee GetSelectedEmployeeById(int selectedEmployeeId);
        int GetTotalSalaryBudgetForCompany();
    }
}
