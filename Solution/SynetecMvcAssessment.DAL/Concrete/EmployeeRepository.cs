using SynetecMvcAssessment.Application.Data;
using SynetecMvcAssessment.Application.Models;
using SynetecMvcAssessment.DAL.Abstract;
using System;
using System.Linq;

namespace SynetecMvcAssessment.DAL.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MvcInterviewV3Entities1 db = new MvcInterviewV3Entities1();

        public BonusPoolCalculatorModel GetAllEmployees()
        {
            try
            {
                return new BonusPoolCalculatorModel
                {
                    AllEmployees = db.HrEmployees.ToList()
                };
            }
            catch (Exception e)
            {
                return new BonusPoolCalculatorModel();
            }
        }

        public HrEmployee GetSelectedEmployeeById(int selectedEmployeeId)
        {
            try
            {
                return db.HrEmployees.FirstOrDefault(item => item.ID == selectedEmployeeId);
            }
            catch (Exception e)
            {
                return new HrEmployee();
            }
        }

        public int GetTotalSalaryBudgetForCompany()
        {
            try
            {
                return db.HrEmployees.Sum(item => item.Salary);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
