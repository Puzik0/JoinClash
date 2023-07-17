using System;
using Model.Obstacles;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot
{
	public class EnvironmentCompositionRoot : CompositionRoot
	{
		[SerializeField] private Trigger[] _obstacles = Array.Empty<Trigger>();
		
		public override void Compose()
		{
			foreach (Trigger obstacle in _obstacles)
			{
				obstacle.Between<Obstacle, (StickmanHorde, StickmanMovement)>(new Obstacle(), handler =>
				{
					(StickmanHorde horde, StickmanMovement stickman) = handler;
					horde.Remove(stickman);
					stickman.Model.TakeDamage(float.MaxValue);
				});
			}
		}
	}
}