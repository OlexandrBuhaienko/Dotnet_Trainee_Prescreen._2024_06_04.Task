using TraineeTask.Models;
using TraineeTask.Solution;

namespace _.NET_Trainee_Task
{
    internal class Program
    {
        static void Main()
        {
            // Example #1
            var team1 = new Employee[]
            {
                new Employee("Misha", "Manager"),
                new Employee("Vam", "Designer"),
                new Employee("Vova", "Designer"),
                new Employee("Leo", "Artist"),
            };

            var salaries1 = new Dictionary<string, Salary>()
            {
                { "Manager", new Salary(1000, "10%") },
                { "Designer", new Salary(600, "30%") },
                { "Artist", new Salary(1500, "15%") },
            };

            var financeReport1 = new BudgetCalculator().Calculate(team1, salaries1);
            Console.WriteLine("Example #1 Finance Report:");
            foreach (var item in financeReport1)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();

            // Example #2
            var team2 = new Employee[]
            {
                new Employee("Alexander", "TeamLead"),
                new Employee("Gaudi", "Architect"),
                new Employee("Koolhas", "Architect"),
                new Employee("Foster", "Architect"),
                new Employee("Napoleon", "General"),
            };

            var salaries2 = new Dictionary<string, Salary>()
            {
                { "TeamLead", new Salary(1000, "99%") },
                { "Architect", new Salary(9000, "34%") },
            };

            var financeReport2 = new BudgetCalculator().Calculate(team2, salaries2);
            Console.WriteLine("Example #2 Finance Report:");
            foreach (var item in financeReport2)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}

