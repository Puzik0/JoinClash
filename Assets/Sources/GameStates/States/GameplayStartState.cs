using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	public class GameplayStartState : IGameState
	{
		private readonly Scene _menu;
		private readonly IAsyncSceneLoading _sceneLoading;

		public GameplayStartState(Scene menu, IAsyncSceneLoading sceneLoading)
		{
			_menu = menu;
			_sceneLoading = sceneLoading;
		}

		public async void Enter()
		{
			await _sceneLoading.UnloadAsync(_menu);
			
		}

		public void Exit()
		{
		}
	}
}