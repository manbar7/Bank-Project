using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Bank : IBank
    {
        private List<Account> accounts = new List<Account>();
        private List<Customer> customers = new List<Customer>();
        private Dictionary<int, Customer> CustomerIDList = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> CustomerNumList = new Dictionary<int, Customer>();
        private Dictionary<int, Account> AccountNumList = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> AccountsByCustomer = new Dictionary<Customer,List<Account>>();
  
        private int totalMoneyInBank;
        private int profits;
        
        internal Bank()
        {

        }
        internal Customer GetCustomerByID(int customerid)
        {
            
            if (CustomerIDList.TryGetValue(customerid, out Customer cust))
                return cust;
            throw new CustomerNotFountException();
        }
        internal Customer GetCustomerByNum(int customernum)
        {
            if (CustomerNumList.TryGetValue(customernum, out Customer cust))
                return cust;
            throw new CustomerNotFountException();
        }
        internal Customer GetAccountByNum(int customernum)
        {
            if (CustomerNumList.TryGetValue(customernum, out Customer cust))
                return cust;
            throw new AccountNotFoundException();
        }
        internal List<Account> GetAccountByCustomer(Customer cust)
        {
            if (AccountsByCustomer.TryGetValue(cust, out List<Account> NewList))
                return NewList;
            throw new CustomerNotFountException();
        }
        internal Customer IfCustNull(Customer cust)
        {
            if (cust == null)
                throw new ArgumentNullException();
            else
                return cust;
        }

        internal void AddNewCustomer (Customer cust)
        {
            if (cust == null)
            {
                throw new CustomerNullException();
            }
            if (customers.Contains(cust))
            {
                throw new CustomerAlreadyExistException();
            }
            else
            {
                customers.Add(cust);
                CustomerIDList.Add(cust.CustomerID, cust);
                CustomerNumList.Add(cust.CustomerNumber, cust);
            }
        }

        internal void OpenNewAccount(Customer cust,Account acc)
        {
            if (accounts.Contains(acc))
                throw new AccountAlreadyExistsException();
            accounts.Add(acc);
            AccountNumList.Add(acc.AccountNumber, acc);
            List<Account> NewList = new List<Account>();
            NewList.Add(acc);
            AccountsByCustomer.Add(cust, NewList);
            totalMoneyInBank = totalMoneyInBank + acc.Balance;


        }
        internal int Deposit(Account acc,int amount)
        {
            if (!accounts.Contains(acc))
                throw new AccountNotFoundException();
            else
                acc.Add(amount);
                totalMoneyInBank = totalMoneyInBank + amount;
                return acc.Balance;
        }

        internal int Withdraw(Account acc,int amount)
        {
            if (!accounts.Contains(acc))
                throw new AccountNotFoundException();
            else
            {
                acc.Subtract(amount);
                totalMoneyInBank = totalMoneyInBank - amount;
                return acc.Balance;
            }
        }

        internal int GetCustomerTotalBalance(Customer cust)
        {
            int sum = 0;
            if (!customers.Contains(cust))
                throw new CustomerNotFountException();
            else
                if (AccountsByCustomer.TryGetValue(cust, out List<Account> NewList))
                foreach (Account acc in NewList)
                {
                    sum = sum + acc.Balance;
                }
            return sum;
        }

        internal void CloseAccount(Account acc,Customer cust)
        {
            if (!customers.Contains(cust) && accounts.Contains(acc))
                throw new CustomerAndAccountNotFoundException();
            if (!customers.Contains(cust))
                throw new CustomerNotFountException();
            if (!accounts.Contains(acc))
                throw new AccountNotFoundException();
            if (acc.Balance < 0)
                throw new BalanceException();
            else
                customers.Remove(cust);
                accounts.Remove(acc);
                CustomerIDList.Remove(cust.CustomerID);
                CustomerNumList.Remove(cust.CustomerNumber);
                AccountNumList.Remove(acc.AccountNumber);
                AccountsByCustomer.Remove(cust);
                totalMoneyInBank = totalMoneyInBank - acc.Balance;

        }

        internal void ChangeAnnualCommissions(float percentage)
        {
            float Commission = 0;
            int CommInt = 0;
            foreach (Account acc in accounts)
            {
                if (acc.Balance < 0)
                {
                    Commission = percentage * 2;
                    if (acc.MaxMinusAllowed < acc.Balance - Commission)
                        throw new NoBalanceForCommissionException();
                        else
                        {
                        Commission = percentage * 2.0f;
                        Commission = acc.Balance * Commission;
                        CommInt = Convert.ToInt32(Commission);
                        acc.Subtract(CommInt);
                        profits = profits + CommInt;
                        }
                }
                else
                {
                    Commission = acc.Balance * Commission;
                    CommInt = Convert.ToInt32(Commission);
                    acc.Subtract(CommInt);
                    profits = profits + CommInt;
                }

            }
        }

         internal void JoinAccounts(Account acc1,Account acc2)
         {        
                Account acc3 = acc1 + acc2;
                CloseAccount(acc1, acc1.AccountOwner);
                CloseAccount(acc2, acc2.AccountOwner);
                AddNewCustomer(acc3.AccountOwner);
                OpenNewAccount(acc3.AccountOwner, acc3);
         }


    
    }
}
 