namespace SRP.NotIdealCode
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal HourlyRate { get; set; }

        public void SaveEmployee(Employee employee)
        {
            // Save employee to database
            Console.WriteLine("Employee saved to database");
        }
        public void SendEmail(Employee employee)
        {
            // Send email to employee
            Console.WriteLine("Email sent to employee");
        }
        public void ReportHours(int hoursWorked)
        {
            // Report hours worked
            Console.WriteLine($"Hours worked: {hoursWorked}");
        }

        public decimal CalculateWeeklySalary(int hoursWorked, decimal hourlyRate)
        {
            // Calculate salary
            return (hoursWorked * hourlyRate);
        }

        public void CalculateMonthlySalary()
        {
            // Calculate salary

            decimal salary = CalculateWeeklySalary(40, 20) * 4;
            Console.WriteLine($"Monthly salary is {salary}");
        }
    }
}
