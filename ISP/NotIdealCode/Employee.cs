namespace ISP.NotIdealCode
{
    public class Employee
    {
        public interface IEmployee
        {
            void Work();              
            void ManageTeam();        
            void PerformAudit();       
            void CodeSoftware();      
            void TestSoftware();       
        }

        public class SoftwareDeveloper : IEmployee
        {
            public void Work()
            {
                Console.WriteLine("Developing software...");
            }

            public void ManageTeam()
            {
                throw new NotSupportedException("Software Developer does not manage a team.");
            }

            public void PerformAudit()
            {
                throw new NotSupportedException("Software Developer does not perform audits.");
            }

            public void CodeSoftware()
            {
                Console.WriteLine("Writing code...");
            }

            public void TestSoftware()
            {
                throw new NotSupportedException("Software Developer does not test software.");
            }
        }

        public class Tester : IEmployee
        {
            public void Work()
            {
                Console.WriteLine("Testing software...");
            }

            public void ManageTeam()
            {
                throw new NotSupportedException("Tester does not manage a team.");
            }

            public void PerformAudit()
            {
                throw new NotSupportedException("Team Lead does not perform audits.");
            }

            public void CodeSoftware()
            {
                throw new NotSupportedException("Team Lead does not write code.");
            }

            public void TestSoftware()
            {
                Console.WriteLine("Testing software...");
            }
        }

        public class TeamLead : IEmployee
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
            public void CodeSoftware()
            {
                throw new NotSupportedException("Manager does not write code.");
            }
            public void TestSoftware()
            {
                throw new NotSupportedException("Manager does not test software.");

            }
        }
    }
}
