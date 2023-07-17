using UnityEngine;

namespace GameStates.Base
{
	[CreateAssetMenu(fileName = "GameStateMachine", menuName = "ScriptableObjects/Game/StateMachine")]
	public class GameStateMachineSo : ScriptableObject, IGameStateMachine
	{
		[SerializeField] private GameStateSo[] _states;
		
		private GameStateMachine _stateMachine;

		private void OnEnable() => 
			_stateMachine = new GameStateMachine(_states);

		public void Enter<TState>() where TState : IGameState => 
			_stateMachine.Enter<TState>();
	}
}