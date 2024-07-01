using System;
using System.Linq;
using System.Collections.Generic;
using TraineeTask.Models;
using TraineeTask.Solution;

namespace TraineeTask.Models
{
    public record Employee(string Name, string Position);

    public record Salary(decimal Amount, string Tax);
}

namespace TraineeTask.Solution
{
    public class BudgetCalculator : IBudgetCalculator
    {
        //start
        public IDictionary<string, decimal> Calculate(IEnumerable<Employee> team, Dictionary<string, Salary> salaries)
        {
            if(team is null)
            {
                throw new NullReferenceException(nameof(team) + "\n!!!!!!!!!\nThe team object is null!\nPlease, use valid data\n!!!!!!!!!\n");
            }
            if(salaries is null)
            {
                throw new NullReferenceException(nameof(salaries) + "\n!!!!!!!!!\nThe salaries object is null!\nPlease use valid data\n!!!!!!!!!\n");
            }
            var report = new Dictionary<string, decimal>();

            decimal totalTeamBudget = 0;

            try
            {
                foreach (var employee in team)
                {
                    if (salaries.ContainsKey(employee.Position))
                    {
                        var salary = salaries[employee.Position];
                        if (salary.Amount < 100 || salary.Amount > 100000)
                        {
                            continue;
                        }
                        if (!int.TryParse(salary.Tax.TrimEnd('%'), out int tax) || tax < 0 || tax > 99)
                        {
                            continue;
                        }
                        decimal taxRate = decimal.Parse(salary.Tax.TrimEnd('%')) / 100;
                        decimal grossSalary = salary.Amount / (1 - taxRate);
                        string positionKey = $"Total{employee.Position}Budget";

                        if (report.ContainsKey(positionKey))
                        {
                            report[positionKey] += Math.Round(grossSalary, 2);
                        }
                        else
                        {
                            report[positionKey] = Math.Round(grossSalary, 2);
                        }

                        totalTeamBudget += Math.Round(grossSalary, 2);
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            

            report["TotalTeamBudget"] = Math.Round(totalTeamBudget, 2);

            return report;
        }
        //finish
    }

    public interface IBudgetCalculator
    {
        IDictionary<string, decimal> Calculate(IEnumerable<Employee> team, Dictionary<string, Salary> salaries);
    }

}
