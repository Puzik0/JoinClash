using System;
using Model.Currency;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot
{
    public class PropsCompositionRoot : CompositionRoot
    {
        [Header("Coins")]
        [SerializeField] private Trigger[] _coins = Array.Empty<Trigger>();
        [SerializeField] [Min(1)]private int _par;

        [Header("Roots")]
        [SerializeField] private CurrencyCompositionRoot _currencyCompositionRoot;

        private Wallet Wallet => _currencyCompositionRoot.Wallet;

        public override void Compose()
        {
            foreach (Trigger trigger in _coins) 
            {
                Coin model = new Coin(_par);

                trigger.Between<Coin, (StickmanHorde, StickmanMovement)>(model, tuple=>
                {
                    Wallet.Add(model);
                });
            }
        }
    }
}