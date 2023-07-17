using System;
using System.Collections.Generic;
using Model;
using Model.Components;
using Model.Obstacles;
using Model.Physics;
using Model.Sources.Model.StateMachine.States.FightStates;
using Model.Sources.Model.StateMachine.States.Movement;
using Model.StateMachine;
using Model.StateMachine.States;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using Sources.CompositeRoot.Extensions;
using Sources.View;
using Sources.View.Extensions;
using UnityEditor.Animations;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot
{
	public class AlliesCompositionRoot : CompositionRoot
	{
		[Header("Roots")] 
		[SerializeField] private EnemiesCompositionRoot _enemiesRoot;
		
		[Header("Preferences")]
		[SerializeField] private float _distanceBetweenBounds;
		[SerializeField] private float _maxMovementSpeed;
		[SerializeField] private float _accelerationTime;
		[SerializeField] private float _health;
		[SerializeField] private StickmanChargeState.Preferences _chargePreferences;
		[SerializeField] private StickmanAttackState.Preferences _attackPreferences;
		
		[Header("Used assets")]
		[SerializeField] private AnimatorController _controller;
		[SerializeField] private CapsuleCollider _pickTriggerZonePrefab;

		[Header("Scene")] 
		[SerializeField] private EventTrigger _pathFinishTrigger;
		[SerializeField] private string _groundTag;
		
		[Header("Views")]
		[SerializeField] private PhysicsTransformableView _playerView;
		[SerializeField] private PhysicsTransformableView[] _otherViews = Array.Empty<PhysicsTransformableView>();

		private Dictionary<StickmanMovement, PhysicsTransformableView> _placedEntities;

		public override void Compose()
		{
			_placedEntities = new Dictionary<StickmanMovement, PhysicsTransformableView>(_otherViews.Length);
			
			Player = Compose(_playerView);
			_placedEntities.Add(Player, _playerView);

			foreach (PhysicsTransformableView view in _otherViews)
			{
				StickmanMovement movement = Compose(view);
				_placedEntities.Add(movement, view);
			}
		}

		public IReadOnlyDictionary<StickmanMovement, PhysicsTransformableView> PlacedEntities => _placedEntities;

		public StickmanMovement Player { get; private set; }
		
		private StickmanMovement Compose(PhysicsTransformableView view)
		{
			var health = new Health(_health);
			var model = new Stickman(health, view.transform.position, view.transform.rotation);
			var inertialMovement = new InertialMovement(_maxMovementSpeed, _accelerationTime);
			var surfaceSliding = new SurfaceSliding(_groundTag);
			var movement = new StickmanMovement(model, surfaceSliding, inertialMovement, _distanceBetweenBounds);

			view
				.Initialize(model)
				.AddComponent<CollisionBroadcaster>()
				.Initialize(surfaceSliding)
				.RequireComponent<Animator>(out var animator)
				.BindController(_controller)
				.AddComponent<TickBroadcaster>()
				.InitializeAs(new StickmanStateMachine(animator, new StickmanState[]
				{
					new StickmanWaitState(StickmanAnimatorParameters.Idle),
					new StickmanIdleState(movement, StickmanAnimatorParameters.Idle),
					new StickmanRunState(movement, StickmanAnimatorParameters.IsRunning),
					new StickmanChargeState(model, _enemiesRoot.Entities, _chargePreferences, StickmanAnimatorParameters.Charge),
					new StickmanAttackState(model, _enemiesRoot.Entities, _attackPreferences, StickmanAnimatorParameters.IsPunching),
					new StickmanDeathState(StickmanAnimatorParameters.IsDead),
					new StickmanVictoryState(StickmanAnimatorParameters.Won)
				}), out var stateMachine)
				.ContinueWith(stateMachine.Enter<StickmanIdleState>)
				.Append(_pickTriggerZonePrefab)
				.GoToParent()
				.AddComponent<Trigger>()
				.Between<StickmanMovement, (StickmanHorde, StickmanMovement)>(movement, handler => handler.Item1.Add(movement))
				.OnTrigger(_pathFinishTrigger)
				.Do(stateMachine.Enter<StickmanChargeState>)
				.ContinueWith(() => model.Died += stateMachine.Enter<StickmanDeathState>);

			return movement;
		}
	}
}