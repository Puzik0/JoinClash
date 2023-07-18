using GameStates.Base;
using GameStates.States;
using SceneLoading;
using UnityEditor;
using UnityEngine;
using PauseState = GameStates.States.PauseState;

namespace Infrastructure
{
	public class GameStateMachineFactory : MonoBehaviour
	{
		[SerializeField] private Scene _level;
		[SerializeField] private Scene _menu;

		public IGameStateMachine Initialize()
		{
			IAsyncSceneLoading sceneLoading = new AddressablesSceneLoading();

			IGameState[] states =
			{
				new BootstrapState(_level, _menu, sceneLoading),
				new GameplayStartState(_menu, sceneLoading),
				new PauseState(),
				new GameplayState()
			};

			return new GameStateMachine(states);
		}
	}
}