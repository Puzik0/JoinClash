using System.Collections;
using UnityEngine;

namespace Model.Currency
{
    public class Coin
    {
        public readonly int Par;

        public Coin(int par)
        {
            Model.Currency.Wallet.CheckBalanceOnNegative(par);

            Par = par;
        }
    }
}