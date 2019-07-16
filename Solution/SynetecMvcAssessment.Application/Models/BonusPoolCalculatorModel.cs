using SynetecMvcAssessment.Application.Data;
using System.Collections.Generic;

namespace SynetecMvcAssessment.Application.Models
{
    public class BonusPoolCalculatorModel
    {
        public int BonusPoolAmount { get; set; }
        public List<HrEmployee> AllEmployees { get; set; }
        public int SelectedEmployeeId { get; set; }
    }
}