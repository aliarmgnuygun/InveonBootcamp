namespace OCP.IdealCode
{
    public class MoneyTransfer
    {
        private readonly IBank _bank;
        public MoneyTransfer(IBank bank)
        {
            _bank = bank;
        }
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            _bank.SendMoney(bankName, accountNumber, amount);
        }
    }

    public interface IBank
    {
        void SendMoney(string bankName, string accountNumber, decimal amount);
    }

    public class Garanti : IBank
    {
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with {bankName}");
        }
    }

    public class Ziraat : IBank
    {
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with {bankName}");
        }
    }

    public class YapiKredi : IBank
    {
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with {bankName}");
        }
    }

    public class Akbank : IBank
    {
        public void SendMoney(string bankName, string accountNumber, decimal amount)
        {
            Console.WriteLine($"Sending {amount} to {accountNumber} with {bankName}");
        }
    }
}
