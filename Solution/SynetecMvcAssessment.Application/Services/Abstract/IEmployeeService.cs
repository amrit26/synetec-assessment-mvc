using SynetecMvcAssessment.Application.Models;

namespace SynetecMvcAssessment.Application.Services.Abstract
{
    public interface IEmployeeService
    {
        BonusPoolCalculatorModel GetAllEmployees();
        BonusPoolCalculatorResultModel GetBonus(BonusPoolCalculatorModel model);
    }
}
