using System;
using System.Collections.Generic;
using Model.StateMachine;
using Model.Stickmen;
using Model.Timers;

namespace Model.Sources.Model.StateMachine.States.FightStates
{
	public class StickmanAttackState : StickmanFightStatesGroup
	{
		[Serializable]
		public struct Preferences
		{
			public float Damage;
			public float TimeBetweenAttacks;
		}

		private readonly float _damage;
		private readonly float _timeBetweenAttacks;

		private readonly Timer _timer = new Timer();
		
		public StickmanAttackState(Stickman model, Func<IEnumerable<Stickman>> enemiesAlive, Preferences preferences, int animationHash) 
			: base(model, enemiesAlive, animationHash)
		{
			_damage = preferences.Damage;
			_timeBetweenAttacks = preferences.TimeBetweenAttacks;
		}

		public override void Tick(float deltaTime, StickmanStateMachine stateMachine)
		{
			base.Tick(deltaTime, stateMachine);

			if (_timer.IsOver)
			{
				ClosestEnemy.TakeDamage(_damage);
				_timer.Start(_timeBetweenAttacks);
			}
			
			_timer.Tick(deltaTime);
		}

		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			base.CheckTransitions(stateMachine);
			
			if (ClosestEnemy.IsDead)
				stateMachine.Enter<StickmanChargeState>();
		}
	}
}