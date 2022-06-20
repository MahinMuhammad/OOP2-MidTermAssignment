using System;

namespace BankAC
{
    public interface BasicBankingInterface
    {
        bool deposit(int amount);
        bool withdraw(int amount);
    }

    abstract class Account : BasicBankingInterface
    {
        protected int balance;
        private String acNum;

        public void setAcNum(String acNum)
        {
            this.acNum = acNum;
        }
        public String getAcNum()
        {
            return acNum;
        }

        public void setBalance(int balance)
        {
            this.balance = balance;
        }
        public int getBalance()
        {
            return balance;
        }

        public bool deposit(int amount)
        {
            if(amount>0)
            {
                balance = balance + amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract bool withdraw(int amount);

        public virtual void showDetails()
        {
            Console.WriteLine("Account Number: " + acNum);
            Console.WriteLine("Balance: " + balance);
        }

    }
    class Current : Account
    {
        private const String acType = "Current";

        public String getACType()
        {
            return acType;
        }

        public override bool withdraw(int amount)
        {
            if(amount>0)
            {
                if (amount <= balance)
                {
                    balance = balance - amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override void showDetails()
        {
            Console.WriteLine("Account type: " + getACType());
            base.showDetails();
        }
    }

    class Savings : Account
    {
        private const int wdPercent = 80;
        private const String acType = "Savings";

        public String getACType()
        {
            return acType;
        }

        public override bool withdraw(int amount)
        {
            if(amount>0)
            {
                if (amount <= ((balance * wdPercent) / 100))
                {
                    balance = balance - amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public override void showDetails()
        {
            Console.WriteLine("Account type: " + getACType());
            Console.WriteLine("Withdraw limit: " + wdPercent + "%");
            base.showDetails();
        }
    }

    class Overdraft : Account
    {
        private readonly int odLimit;
        private const String acType = "Overdraft";

        public Overdraft(int odLimit)
        {
            this.odLimit = odLimit;
        }

        public String getACType()
        {
            return acType;
        }

        public override bool withdraw(int amount)
        {
            if(amount>0)
            {
                if (amount <= (balance + odLimit))
                {
                    balance = balance - amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override void showDetails()
        {
            Console.WriteLine("Account type: " + getACType());
            Console.WriteLine("Overdraft limit: " + odLimit);
            base.showDetails();
        }
    }

    class Clint
    {
        private String name;
        private String profession;
        private String nid;
        private Account ac = new Current();

        public void setName(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
        public void setProfession(String profession)
        {
            this.profession = profession;
        }
        public String getProfession()
        {
            return profession;
        }
        public String NID {
            set
            {
                if(value.Length==10)
                {
                    nid = value;
                }
                else
                {
                    Console.WriteLine("Invalid NID number!");
                }
            }
            get
            {
                return nid;
            }
        }

        public Account getAcccount()
        {
            return ac;
        }
        public void changeAccount(String acType)
        {
            int balance = ac.getBalance();
            String acNum = ac.getAcNum();
            if(acType=="Current")
            {
                ac = new Current();
                ac.setAcNum(acNum);
                ac.setBalance(balance);
                Console.WriteLine("\nAccount changed to " + acType);
            }
            else if (acType == "Savings")
            {
                ac = new Savings();
                ac.setAcNum(acNum);
                ac.setBalance(balance);
                Console.WriteLine("\nAccount successfully changed to " + acType);
            }
            else if (acType == "Overdraft")
            {
                Console.Write("Enter Overdraft limit: ");
                ac = new Overdraft(Convert.ToInt32(Console.ReadLine()));
                ac.setAcNum(acNum);
                ac.setBalance(balance);
                Console.WriteLine("\nAccount successfully changed to " + acType);
            }
            else
            {
                Console.WriteLine("Invalid account type");
            }
        }
        public void showDetails()
        {
            Console.WriteLine("\nName: " + name);
            Console.WriteLine("Profession: " + profession);
            Console.WriteLine("NID: " + NID);
            ac.showDetails();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clint cl = new Clint();
            Console.WriteLine("      Welcome to ABC Bank");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("      Clint Registration");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.Write("Enter Name: ");
            cl.setName(Console.ReadLine());
            Console.Write("Enter Profession: ");
            cl.setProfession(Console.ReadLine());
            Console.Write("Enter NID number: ");
            cl.NID = Console.ReadLine();
            Console.Write("Enter Account number: ");
            cl.getAcccount().setAcNum(Console.ReadLine());
            Console.Write("\nEnter Amount to deposit: ");
            if(cl.getAcccount().deposit(Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Deposit successful..");
            }
            else
            {
                Console.WriteLine("Invalid amount..");
            }
            Console.WriteLine("\nAccount Status below:");
            cl.showDetails();
            Console.WriteLine("\nEnter new account type below: ");
            Console.WriteLine("(Current, Savings, Overdraft)");
            cl.changeAccount(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("\nAccount Status below:");
            cl.showDetails();
            Console.WriteLine("Enter amount to withdraw: ");
            if(cl.getAcccount().withdraw(Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Withdrawal successful");
            }
            else
            {
                Console.WriteLine("Either amount is not greater than zero or exceeds " +
                    "withdrawal Limit");
            }
            Console.ReadKey();
        }
    }
} 