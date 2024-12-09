namespace SRP.IdealCode
{
    public class SalaryService
    {
        public decimal CalculateWeeklySalary(int hoursWorked, decimal hourlyRate)
        {
            // Calculate salary
            decimal weeklySalary = hoursWorked * hourlyRate;
            return weeklySalary;
        }
        public void CalculateMonthlySalary()
        {
            // Calculate salary
            decimal salary = CalculateWeeklySalary(40, 20) * 4;
            Console.WriteLine($"Monthly salary is {salary}");
        }
    }
}
