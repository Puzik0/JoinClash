using GameStates.Base;
using SceneLoading;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameStates.States
{
    public class GameplayState : IGameState
    {
        private readonly Scene _menu;
        private readonly IAsyncSceneLoading _sceneLoading;

        public GameplayState(Scene menu, IAsyncSceneLoading sceneLoading)
        {
            _menu = menu;
            _sceneLoading = sceneLoading;
        }

        public async void Enter()
        {
            await _sceneLoading.UnloadAsync(_menu);
            Debug.Log("GameStarted");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}