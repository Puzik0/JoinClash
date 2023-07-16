using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Input;
using Input.Stickmen;
using Input.Touches;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using Sources.View;
using UnityEngine;

namespace Sources.CompositeRoot
{
	public class HordeCompositionRoot : CompositionRoot
	{
		[Header("Input")]
		[SerializeField] private InputSwipePanel _swipePanel;
		[SerializeField] private InputTouchPanel _touchPanel;
		[SerializeField] private Camera _camera;

		[Header("Roots")]
		[SerializeField] private AlliesCompositionRoot _allies;

		[Header("Camera")]
		[SerializeField] private CinemachineTargetGroup _targetGroup;
		
		private HordeInputRouter _inputRouter;
		private HordeViewChanger _viewChanger;
		private StickmanHorde _horde;

		public override void Compose()
		{
			_horde = new StickmanHorde(_allies.Player);
			var hordeMovement = new StickmanHordeMovement(_horde);
			_inputRouter = new HordeInputRouter(_swipePanel, _touchPanel, hordeMovement, _camera);
			_viewChanger = new HordeViewChanger(_horde, _targetGroup, _allies.PlacedEntities).Initialize();
		}

		public IEnumerable<Stickman> Entities()
		{
			return _horde.Entities.Where(x => x.IsDead == false);
		}

		private void OnEnable()
		{
			_inputRouter.OnEnable();
			_viewChanger.OnEnable();
		}

		private void OnDisable()
		{
			_inputRouter.OnDisable();
			_viewChanger.OnDisable();
		}
	}
}