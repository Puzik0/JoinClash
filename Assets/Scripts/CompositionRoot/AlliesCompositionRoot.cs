using System;
using System.Collections.Generic;
using Model;
using Model.Physics;
using Model.Stickmen;
using Sources.View;
using UnityEngine;

namespace Sources.CompositionRoot
{
	public class AlliesCompositionRoot : CompositionRoot
	{
		[SerializeField] private float _distanceBetweenBounds;
		[SerializeField] private float _maxMovementSpeed;
		[SerializeField] private float _accelerationTime;

		[SerializeField] private TransformableView _playerView;
		[SerializeField] private TransformableView[] _otherViews = Array.Empty<TransformableView>();

		private Dictionary<TransformableView, StickmanMovement> _placedEntities;

		public override void Compose()
		{
			_placedEntities = new Dictionary<TransformableView, StickmanMovement>(_otherViews.Length);
			
			Player = Compose(_playerView);
			
			foreach (TransformableView view in _otherViews)
			{
				StickmanMovement movement = Compose(view);
				_placedEntities.Add(view, movement);
			}
		}

		public IReadOnlyDictionary<TransformableView, StickmanMovement> PlacedEntities => _placedEntities;

		public StickmanMovement Player { get; private set; }

		private StickmanMovement Compose(TransformableView view)
		{
			var model = new Stickman(view.transform.position, view.transform.rotation);
			var inertialMovement = new InertialMovement(_maxMovementSpeed, _accelerationTime);
			var surfaceSliding = new SurfaceSliding();
			var movement = new StickmanMovement(model, surfaceSliding, inertialMovement,
				_distanceBetweenBounds);

			view.gameObject.AddComponent<CollisionBroadcaster>().Initialize(surfaceSliding);
			view.gameObject.AddComponent<GravityBroadcaster>().Initialize(model);
			view.Initialize(model);

			return movement;
		}
	}
}