using UnityEngine;

namespace GameStates.Base
{
	public abstract class GameStateSo : ScriptableObject, IGameState
	{
		public abstract void Enter();
		public abstract void Exit();
	}
}