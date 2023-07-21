using System;
using Model.Currency;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using Sources.CompositeRoot.Extensions;
using Sources.View.Extensions;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot
{
    public class PropsCompositionRoot : CompositionRoot
    {
        [Header("Audio")]
        [SerializeField] private AudioClip _pickedsound;

        [Header("Coins")]
        [SerializeField] private Trigger[] _coins = Array.Empty<Trigger>();
        [SerializeField] [Min(1)]private int _par;

        [Header("Roots")]
        [SerializeField] private CurrencyCompositionRoot _currencyCompositionRoot;
        [SerializeField] private AlliesCompositionRoot _alliesRoot;

       

        private Wallet Wallet => _currencyCompositionRoot.Wallet;

        public override void Compose()
        {
            foreach (Trigger trigger in _coins) 
            {
                Coin model = new Coin(_par);

                trigger.Between<Coin, (StickmanHorde, StickmanMovement)>(model, tuple=>
                {
                    Wallet.Add(model);
                    trigger.gameObject.SetActive(false);

                    (_, StickmanMovement stickman) = tuple;
                    _alliesRoot
                    .ViewOf(stickman)
                    .TakeGameObject()
                    .RequireComponent<AudioSource>()
                    .PlayOneShot(_pickedsound);
                });
            }
        }
    }
}