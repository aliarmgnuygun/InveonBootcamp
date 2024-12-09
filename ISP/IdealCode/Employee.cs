namespace ISP.IdealCode
{
    public class Employee
    {
        public interface IEmployee
        {
            void Work();
        }

        public interface IManager
        {
            void ManageTeam();
            void PerformAudit();
        }

        public interface IDeveloper
        {
            void CodeSoftware();
        }

        public interface ITester
        {
            void TestSoftware();
        }

        public class SoftwareDeveloper : IEmployee, IDeveloper
        {
            public void Work()
            {
                Console.WriteLine("Developing software...");
            }
            public void CodeSoftware()
            {
                Console.WriteLine("Writing code...");
            }
        }

        public class Tester : IEmployee, ITester
        {
            public void Work()
            {
                Console.WriteLine("Testing software...");
            }
            public void TestSoftware()
            {
                Console.WriteLine("Testing software...");
            }
        }

        public class TeamLead : IEmployee, IManager
        {
            public void Work()
            {
                Console.WriteLine("Managing team...");
            }
            public void ManageTeam()
            {
                Console.WriteLine("Managing team...");
            }
            public void PerformAudit()
            {
                Console.WriteLine("Performing audit...");
            }
        }
    }
}
