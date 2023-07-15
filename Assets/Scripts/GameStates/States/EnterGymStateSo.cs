using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = "EnterGymState", menuName = "ScriptableObjects/Game/States/EnterGymState")]

    public class EnterGymStateSo : GameStateSo
    {
        [SerializeField] private Scene _gym;

        private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
        public override void Enter()
        {
            _sceneLoading.LoadAsync(_gym);
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}