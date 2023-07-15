using Assets.Scripts.GameStates.States;
using GameStates.Base;
using GameStates.States;
using SceneLoading;
using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class GameStateMechineFactory : MonoBehaviour
    {
        [SerializeField] private Scene _Level;
        [SerializeField] private Scene _menu;
       public IGameStateMachine initialize()
        {
            IAsyncSceneLoading sceneLoading = new AddressablesSceneLoading();

            IGameState[] states =
            {
                new BootStrapState(_Level, _menu, sceneLoading ),
                new GameplayState(_menu, sceneLoading)
            };
            return new GameStateMachine(states);
        }
    }
}