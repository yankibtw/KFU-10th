using System;
using System.Collections.Generic;
using Tumakov;

namespace TUmakov
{
    internal class BankFabric
    {
        private static readonly Dictionary<uint, Bank> accountDictionary = new Dictionary<uint, Bank>();

        public static uint CreateAccount(decimal balance, BankTypes type)
        {
            Bank newAccount = new Bank(balance, type);
            accountDictionary.Add(newAccount.accountNumber, newAccount);
            return newAccount.accountNumber;
        }
        public static uint CreateAccount()
        {
            return CreateAccount(0, 0);
        }
        public static void CloseAccount(uint accountNumber)
        {
            if (accountDictionary.ContainsKey(accountNumber))
            {
                accountDictionary.Remove(accountNumber);
                Console.WriteLine($"Номер счета {accountNumber} был закрыт.");
            }
            else
                Console.WriteLine($"Номер счета {accountNumber} не зайден.");

        }
    }
}
