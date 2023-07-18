using System;
using UnityEngine;

namespace Model.Currency
{
    public class Wallet : MonoBehaviour
    {
        public Wallet(int balance)
        {
            CheckBalanceOnNegative(balance);
            Balance = balance;
        }
        public event Action Changed;
        

        public int Balance {  get; private set; }

        public void Add(int balance)
        {
            CheckBalanceOnNegative(balance);
            Balance += balance;
            Changed?.Invoke();
        }
        public void TrySpend(int balance)
        {
            CheckBalanceOnNegative(balance);

            if (Balance < balance)
                return;

            Balance -= balance;
            Changed?.Invoke();

        }
        public static void CheckBalanceOnNegative(int balance)
        {
            if (balance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(balance));

                //Debug.LogWarning("Ппопытка прибавить отрицательный баланс. приравнен к 0 ");
                //balance = 0;
            }
        }

    }
}