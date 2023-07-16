using System;
using System.Collections.Generic;
using System.Linq;
using Model.Components;
using Model.Sources.Model.StateMachine.States.FightStates;
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
	public class EnemiesCompositionRoot : CompositionRoot
	{
		[Header("Preferences")] 
		[SerializeField] private float _health;
		[SerializeField] private StickmanChargeState.Preferences _chargePreferences;
		[SerializeField] private StickmanAttackState.Preferences _attackPreferences;
		
		[Header("Roots")] 
		[SerializeField] private HordeCompositionRoot _hordeRoot;
		
		[Header("Scene Events")]
		[SerializeField] private EventTrigger _pathFinishTrigger;

		[Header("Used assets")]
		[SerializeField] private AnimatorController _controller;
		
		[Header("Views")]
		[SerializeField] private TransformableView[] _enemies = Array.Empty<TransformableView>();

		private List<Stickman> _entities;

		public override void Compose()
		{
			_entities = new List<Stickman>(_enemies.Length);
			
			foreach (TransformableView view in _enemies)
				_entities.Add(Compose(view));
		}

		public IEnumerable<Stickman> Entities()
		{
			return _entities.Where(x => x.IsDead == false);
		}
		
		private Stickman Compose(TransformableView view)
		{
			var health = new Health(_health);
			var model = new Stickman(health, view.transform.position, view.transform.rotation);

			view
				.Initialize(model)
				.RequireComponent<Animator>(out var animator)
				.BindController(_controller)
				.AddComponent<TickBroadcaster>()
				.InitializeAs(new StickmanStateMachine(animator, new StickmanState[]
				{
					new StickmanWaitState(StickmanAnimatorParameters.Idle),
					new StickmanChargeState(model, _hordeRoot.Entities, _chargePreferences, StickmanAnimatorParameters.Charge),
					new StickmanAttackState(model, _hordeRoot.Entities, _attackPreferences , StickmanAnimatorParameters.IsPunching),
					new StickmanDeathState(StickmanAnimatorParameters.IsDead)
				}), out var stateMachine)
				.ContinueWith(stateMachine.Enter<StickmanWaitState>)
				.OnTrigger(_pathFinishTrigger)
				.ReactOnce(stateMachine.Enter<StickmanChargeState>)
				.ContinueWith(() => model.Died += stateMachine.Enter<StickmanDeathState>);

			return model;
		}
	}
}