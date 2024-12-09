namespace LSP.NotIdealCode
{
    public abstract class CloudPlatform
    {
        public abstract void DeployServer();
        public abstract void Translate();
        public abstract void BackupDatabase();

    }

    public class Azure : CloudPlatform
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on Azure");
        }
        public override void Translate()
        {
           throw new NotSupportedException("Azure does not support translating");
        }
        public override void BackupDatabase()
        {
            throw new NotSupportedException("Azure does not support backing up database");
        }
    }

    public class Aws : CloudPlatform
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on AWS");
        }
        public override void Translate()
        {
            Console.WriteLine("Translating on AWS");
        }
        public override void BackupDatabase()
        {
            Console.WriteLine("Backing up database on AWS");
        }
    }

    public class GoogleCloud : CloudPlatform
    {
        public override void DeployServer()
        {
            Console.WriteLine("Deploying server on Google Cloud");
        }
        public override void Translate()
        {
            Console.WriteLine("Translating on Google Cloud");
        }
        public override void BackupDatabase()
        {
            throw new NotSupportedException("Google Cloud does not support backing up database");
        }
    }


}
