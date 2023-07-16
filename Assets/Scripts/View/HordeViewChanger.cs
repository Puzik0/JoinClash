using System.Collections.Generic;
using Cinemachine;
using Model.Stickmen;
using Sources.View.Extensions;
using View.Sources.View.Broadcasters;

namespace Sources.View
{
	public class HordeViewChanger
	{
		private readonly StickmanHorde _horde;
		private readonly CinemachineTargetGroup _targetGroup;
		private readonly IReadOnlyDictionary<StickmanMovement, TransformableView> _placedEntities;

		public HordeViewChanger(StickmanHorde horde, CinemachineTargetGroup targetGroup, IReadOnlyDictionary<StickmanMovement, TransformableView> placedEntities)
		{
			_horde = horde;
			_targetGroup = targetGroup;
			_placedEntities = placedEntities;
		}

		public HordeViewChanger Initialize()
		{
			foreach (StickmanMovement stickmanMovement in _horde.Stickmans)
				TryChange(stickmanMovement);

			return this;
		}

		public void OnEnable()
		{
			_horde.Added += TryChange;
		}

		public void OnDisable()
		{
			_horde.Added -= TryChange;
		}

		private void TryChange(StickmanMovement stickman)
		{
			if (_placedEntities.TryGetValue(stickman, out var view) == false)
				return;

			view.gameObject
				.RequireComponent<Trigger>()
				.Between<StickmanHorde, StickmanMovement>(_horde);
			
			_targetGroup.AddMember(view.transform, 1 ,1);
		}
	}
}