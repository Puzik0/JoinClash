using GameStates.Base;
using GameStates.States;
using StaticContext;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameStateMechineFactory _stateMachineFactory;

        private void OnEnable()
        {
            IGameStateMachine stateMachine = _stateMachineFactory.initialize();

            Instance<IGameStateMachine>.Value = stateMachine;

            stateMachine.Enter<BootStrapState>();
        }
    }
}