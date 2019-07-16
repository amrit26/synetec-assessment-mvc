using SynetecMvcAssessment.Application.DAL.Abstract;
using SynetecMvcAssessment.Application.ModelBuilders.Abstract;
using SynetecMvcAssessment.Application.Models;

namespace SynetecMvcAssessment.Application.ModelBuilders.Concrete
{
    public class BonusPoolModelBuilder : IBonusPoolModelBuilder
    {
        private readonly IEmployeeRepository _employeeRepository;

        public BonusPoolModelBuilder(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public BonusPoolCalculatorModel Build()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}
