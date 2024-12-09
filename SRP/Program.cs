#region Not Ideal Code
/*
using SRP.NotIdealCode;

Employee employee = new();
employee.Name = "John Doe";
employee.Email = "johndoe@gmail.com";
employee.HourlyRate = 20;

employee.SaveEmployee(employee);
employee.SendEmail(employee);
employee.CalculateWeeklySalary(40, employee.HourlyRate);
employee.CalculateMonthlySalary();
employee.ReportHours(40);
*/

#endregion

#region Ideal Code
using SRP.IdealCode;
Employee employee = new()
{
    Name = "John Doe",
    Email = "johndoe@gmail.com",
    HourlyRate = 20
};

EmployeeRepository employeeRepository = new();
SalaryService salaryService = new();
HRService hrService = new();
MailService mailService = new();

employeeRepository.SaveEmployee(employee);
salaryService.CalculateWeeklySalary(40, employee.HourlyRate);
salaryService.CalculateMonthlySalary();
mailService.SendMail(employee.Email, "Your salary has been paid.");
hrService.ReportHours(40);
mailService.SendMail(employee.Email, "Your hours have been reported.");

#endregion