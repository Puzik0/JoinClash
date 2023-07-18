using System;
using System.Collections.Generic;
using Model.StateMachine;
using Model.Stickmen;
using Model.Timers;
using UnityEngine;

namespace Model.Sources.Model.StateMachine.States.FightStates
{
	public class StickmanAttackState : StickmanFightStatesGroup
	{
		[Serializable]
		public struct Preferences
		{
			public float Damage;
			public float TimeBetweenAttacks;
			public AudioClip Punchsound;
		}

		private readonly float _damage;
		private readonly float _timeBetweenAttacks;
		private readonly AudioClip _punchsound;
		private readonly AudioSource _audioSource;

		private readonly Timer _timer = new Timer();

		public StickmanAttackState(Stickman model,
									Func<IEnumerable<Stickman>> enemiesAlive,
									Preferences preferences,
									AudioSource audioSource,
									int animationHash)
			: base(model, enemiesAlive, animationHash)
		{
			_damage = preferences.Damage;
			_timeBetweenAttacks = preferences.TimeBetweenAttacks;
			_punchsound = preferences.Punchsound;
			_audioSource = audioSource;
		}

		public override void Tick(float deltaTime, StickmanStateMachine stateMachine)
		{
			base.Tick(deltaTime, stateMachine);

			if (_timer.IsOver)
                Punch(ClosestEnemy);
			

			_timer.Tick(deltaTime);
		}


		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			base.CheckTransitions(stateMachine);

			if (ClosestEnemy.IsDead)
				stateMachine.Enter<StickmanChargeState>();
		}


		private void Punch(Stickman enemy)
		{
			enemy.TakeDamage(_damage);
			_audioSource.PlayOneShot(_punchsound);
			_timer.Start(_timeBetweenAttacks);


		}
	}
}