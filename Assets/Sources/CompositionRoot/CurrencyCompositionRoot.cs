using Model.Currency;
using Sources.CompositeRoot.Base;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class CurrencyCompositionRoot : CompositionRoot
    {
        public Wallet Wallet { get; private set; }
        public override void Compose()
        {
            Wallet = new Wallet(0);
        }
    }
}