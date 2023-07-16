using Input;
using Input.Stickmen;
using Input.Touches;
using Model.Stickman;
using UnityEngine;

namespace Scripts.CompositionRoot
{
    public class HordeCompositionRoot : CompositionRoot
    {
        [Header("Input")]
        [SerializeField] private InputSwipePanel _swipePanel;
        [SerializeField] private InputTouchPanel _touchPanel;
        [SerializeField] private Camera _camera;

        [Header("Roots")]
        [SerializeField] private AlliesCompositionRoot _allies;

        private HordeInputRouter _inputRouter;

        public override void Compose()
        {
            Horde = new StickmanHorde(_allies.Player);
            StickmanHordeMovement hordeMovement = new StickmanHordeMovement(Horde);

            _inputRouter = new HordeInputRouter(_swipePanel, _touchPanel, hordeMovement, _camera);
        }

        public StickmanHorde Horde { get; private set; }

        private void OnEnable()
        {
            _inputRouter.OnEnable();
        }

        private void OnDisable()
        {
            _inputRouter.OnDisable();
        }
    }
}