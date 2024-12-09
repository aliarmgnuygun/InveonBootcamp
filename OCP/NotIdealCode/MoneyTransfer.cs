namespace OCP.NotIdealCode
{
    public class MoneyTransfer
    {
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            if (bankName == "Garanti")
            {
                var garanti = new Garanti();
                garanti.SendMoney(accountNumber, amount);
            }
            else if (bankName == "Ziraat")
            {
                var ziraat = new Ziraat();
                ziraat.SendMoney(accountNumber, amount);
            }
            else if (bankName == "YapiKredi")
            {
                var yapiKredi = new YapiKredi();
                yapiKredi.SendMoney(accountNumber, amount);
            }
            else if (bankName == "Akbank")
            {
                var akbank = new Akbank();
                akbank.SendMoney(accountNumber, amount);
            }
            else
            {
                Console.WriteLine($"Bank {bankName} is not supported.");
            }
        }
    }

    public class Garanti
    {
        public void SendMoney(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with Garanti");
        }
    }

    public class Ziraat
    {
        public void SendMoney(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with Ziraat");
        }
    }

    public class YapiKredi
    {
        public void SendMoney(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with YapiKredi");
        }
    }

    public class Akbank
    {
        public void SendMoney(string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with Akbank");
        }
    }
}