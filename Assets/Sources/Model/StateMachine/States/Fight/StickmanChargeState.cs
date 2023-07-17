using System;
using System.Collections.Generic;
using Model.StateMachine;
using Model.Stickmen;
using UnityEngine;

namespace Model.Sources.Model.StateMachine.States.FightStates
{
	public class StickmanChargeState : StickmanFightStatesGroup
	{
		[Serializable]
		public struct Preferences
		{
			public float Speed;
			public float AttackDistance;
		}

		private readonly float _speed;
		private readonly float _attackDistance;

		public StickmanChargeState(Stickman model, Func<IEnumerable<Stickman>> enemiesAlive, Preferences preferences, int animationHash)
			: base(model, enemiesAlive, animationHash)
		{
			_speed = preferences.Speed;
			_attackDistance = preferences.AttackDistance;
		}

		public override void Tick(float deltaTime, StickmanStateMachine stateMachine)
		{
			base.Tick(deltaTime, stateMachine);

			Vector3 position = Vector3.MoveTowards(Model.Position, ClosestEnemy.Position, deltaTime * _speed);
			Model.Move(position);
			Model.LookAt(position);
		}

		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			base.CheckTransitions(stateMachine);
			
			float sqrMagnitude = (Model.Position - ClosestEnemy.Position).sqrMagnitude;
			
			if (sqrMagnitude < _attackDistance * _attackDistance)
				stateMachine.Enter<StickmanAttackState>();
		}
	}
}