using SynetecMvcAssessment.Application.Data;
using SynetecMvcAssessment.Application.Models;

namespace SynetecMvcAssessment.Application.DAL.Abstract
{
    public interface IEmployeeRepository
    {
        BonusPoolCalculatorModel GetAllEmployees();
        HrEmployee GetSelectedEmployeeById(int selectedEmployeeId);
        int GetTotalSalaryBudgetForCompany();
    }
}
