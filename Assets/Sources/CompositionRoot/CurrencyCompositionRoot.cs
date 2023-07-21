using Model.Currency;
using Sources.CompositeRoot.Base;
using Sources.View.UI;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class CurrencyCompositionRoot : CompositionRoot
    {
        [SerializeField] private WalletView _walletView;
        public Wallet Wallet { get; private set; }
        public override void Compose()
        {
            Wallet = new Wallet(0);
            _walletView.Initialize(Wallet);





        }
    }
}