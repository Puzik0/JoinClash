using System.Collections;
using UnityEngine;

namespace Model.Currency
{
    public class Coin : MonoBehaviour
    {
        public readonly int Par;

        public Coin(int par)
        {
            Model.Currency.Wallet.CheckBalanceOnNegative(par);

            Par = par;
        }
    }
}