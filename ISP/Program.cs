#region Not Ideal Code
/*
using ISP.NotIdealCode;

Console.WriteLine("=== Not Ideal Code Example ===");

// Software Developer
var softwareDeveloper = new Employee.SoftwareDeveloper();
softwareDeveloper.Work();

try
{
    softwareDeveloper.ManageTeam();
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

try
{
    softwareDeveloper.PerformAudit();
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Tester
var tester = new Employee.Tester();
tester.Work();

try
{
    tester.ManageTeam(); 
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Team Lead
var teamLead = new Employee.TeamLead();
teamLead.Work();
teamLead.ManageTeam();

try
{
    teamLead.CodeSoftware(); 
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
*/
#endregion

#region Ideal Code

using static ISP.IdealCode.Employee;

Console.WriteLine("\n=== Ideal Code Example ===");

// Software Developer
IEmployee developer = new SoftwareDeveloper();
developer.Work();

if (developer is IDeveloper coder)
{
    coder.CodeSoftware();
}

// Tester
IEmployee tester = new Tester();
tester.Work();
if(tester is ITester softwareTester)
{
    softwareTester.TestSoftware();
}

// Team Lead
IEmployee teamLead = new TeamLead();
teamLead.Work();
if (teamLead is IManager manager)
{
    manager.ManageTeam();
    manager.PerformAudit();
}
#endregion
