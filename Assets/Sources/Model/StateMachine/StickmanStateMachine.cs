using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model.StateMachine
{
	public class StickmanStateMachine : ITickable
	{
		private readonly Animator _animator;
		
		private readonly Dictionary<Type, StickmanState> _states = new Dictionary<Type, StickmanState>();
		private StickmanState _currentState = new StickmanState.None();

		public StickmanStateMachine(Animator animator, IEnumerable<StickmanState> states)
		{
			_animator = animator;
			
			foreach (StickmanState stickmanState in states)
			{
				Type key = stickmanState.GetType();

				if (_states.ContainsKey(key))
					throw new InvalidOperationException($"Trying to register duplicate state {key}");
				
				_states.Add(key, stickmanState);
			}
		}

		public void Enter<TState>() where TState : StickmanState
		{
			if (_states.TryGetValue(typeof(TState), out var newState) == false)
				throw new InvalidOperationException($"Trying to enter unregistered state {nameof(TState)}");

			if (_currentState == newState)
				return;
			
			_currentState.Exit(_animator, this);
			_currentState = newState;
			_currentState.Enter(_animator, this);
		}

		public void Tick(float deltaTime)
		{
			_currentState.Tick(deltaTime, this);
		}
	}
}