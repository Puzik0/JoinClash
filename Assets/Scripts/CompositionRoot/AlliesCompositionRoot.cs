using System;
using System.Collections.Generic;
using Model;
using Model.Physics;
using Model.StateMachine;
using Model.StateMachine.States;
using Model.StateMachine.States.Groups;
using Model.Stickmen;
using Sources.CompositionRoot.Extensions;
using Sources.View;
using UnityEditor.Animations;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositionRoot
{
	public class AlliesCompositionRoot : CompositionRoot
	{
		[SerializeField] private float _distanceBetweenBounds;
		[SerializeField] private float _maxMovementSpeed;
		[SerializeField] private float _accelerationTime;

		[SerializeField] private AnimatorController _controller;
		
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
			
			Animator animator = view.gameObject.RequireComponent<Animator>();
			animator.runtimeAnimatorController = _controller;
			
			var stateMachine = new StickmanStateMachine(new StickmanState[]
			{
				new StickmanIdleState(animator, movement, StickmanAnimatorParameters.Idle),
				new StickmanRunState(animator, movement, StickmanAnimatorParameters.IsRunning),
				new StickmanMoveStatesGroup(animator, movement, StickmanAnimatorParameters.Move)
			});
			
			stateMachine.Enter<StickmanMoveStatesGroup>();
			
			view.gameObject.AddComponent<TickBroadcaster>().Initialize(stateMachine);

			return movement;
		}
	}
}