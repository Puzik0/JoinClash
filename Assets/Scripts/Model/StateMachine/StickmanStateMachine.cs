using System;
using System.Collections.Generic;

namespace Model.StateMachine
{
	public class StickmanStateMachine : ITickable
	{
		private readonly Dictionary<Type, StickmanState> _states = new Dictionary<Type, StickmanState>();
		private StickmanState _currentState = new StickmanState.None();

		public StickmanStateMachine(IEnumerable<StickmanState> states)
		{
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
			
			_currentState.Exit(this);
			_currentState = newState;
			_currentState.Enter(this);
		}

		public void Tick(float deltaTime)
		{
			_currentState.Tick(deltaTime, this);
		}
	}
}