using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{

    public class BootStrapState : IGameState
    {
        private readonly Scene _level;
        private readonly Scene _menu;
        private readonly IAsyncSceneLoading _sceneLoading;

        public BootStrapState(Scene gym, Scene menu, IAsyncSceneLoading sceneLoading)
        {
            _level = gym;
            _menu = menu;
            _sceneLoading = sceneLoading;            
        }

        public void Enter()
        {
            _sceneLoading.LoadAsync(_level);
            _sceneLoading.LoadAsync(_menu);
        }

        public void Exit()
        {
            
        }
    }
}