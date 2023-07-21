using System.Collections;
using UnityEngine;

namespace Model.Currency
{
    public static class WalletExtensions
    {

        public static void Add(this Wallet wallet, Coin coin) =>
            wallet.Add(coin.Par);


    }
}