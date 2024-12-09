#region Not Ideal Code
/*
using LSP.NotIdealCode;

CloudPlatform cloud = new Aws();
cloud.DeployServer();
cloud.Translate();
cloud.BackupDatabase();

cloud = new Azure();
cloud.DeployServer();
cloud.Translate();

if (cloud is not Azure)
{
   cloud.BackupDatabase();
}
else
{
    Console.WriteLine("Azure does not support backing up database");
}

cloud = new GoogleCloud();
cloud.DeployServer();
cloud.Translate();
cloud.BackupDatabase();
*/
#endregion

#region Ideal Code

using LSP.IdealCode;

CloudPlatform cloud = new Aws();
(cloud as ITranslationOperation)?.Translate();
(cloud as IDatabaseOperation)?.BackupDatabase();
cloud.DeployServer();

cloud = new Azure();
cloud.DeployServer();


cloud = new GoogleCloud();
cloud.DeployServer();
(cloud as ITranslationOperation)?.Translate();

#endregion