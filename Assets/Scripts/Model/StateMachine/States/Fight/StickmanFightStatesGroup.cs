using System;
using System.Collections.Generic;
using System.Linq;
using Model.Extensions;
using Model.StateMachine;
using Model.StateMachine.States;
using Model.Stickmen;
using UnityEngine;

namespace Model.Sources.Model.StateMachine.States.FightStates
{
	public abstract class StickmanFightStatesGroup : StickmanState
	{
		protected readonly Stickman Model;
		private readonly Func<IEnumerable<Stickman>> _enemiesAlive;

		protected StickmanFightStatesGroup(Stickman model, Func<IEnumerable<Stickman>> enemiesAlive, int animationHash)
			: base(animationHash)
		{
			Model = model;
			_enemiesAlive = enemiesAlive;
		}
		
		protected Stickman ClosestEnemy { get; private set; }

		public override void Enter(Animator animator, StickmanStateMachine stateMachine)
		{
			base.Enter(animator, stateMachine);

			IEnumerable<Stickman> enemies = _enemiesAlive.Invoke();

			if (enemies.Any() == false)
			{
				stateMachine.Enter<StickmanWaitState>();
				return;
			}

			ClosestEnemy = enemies.ClosestTo(Model);
		}
	}
}