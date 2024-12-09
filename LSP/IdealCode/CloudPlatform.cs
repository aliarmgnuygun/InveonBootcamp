namespace LSP.IdealCode
{
    public abstract class CloudPlatform
    {
        public abstract void DeployServer();
    }
    public interface IDatabaseOperation
    {
        void BackupDatabase();
    }

    public interface ITranslationOperation
    {
        void Translate();
    }

    public class Azure : CloudPlatform
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on Azure");
        }
    }

    public class Aws : CloudPlatform, IDatabaseOperation, ITranslationOperation
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on AWS");
        }
        public void Translate()
        {
            Console.WriteLine("Translating on AWS");
        }
        public void BackupDatabase()
        {
            Console.WriteLine("Backing up database on AWS");
        }
    }

    public class GoogleCloud : CloudPlatform, ITranslationOperation
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on Google Cloud");
        }
        public void Translate()
        {
            Console.WriteLine("Translating on Google Cloud");
        }
    }
}
