using GameStates.Base;
using GameStates.States;
using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameStateMachineSo _stateMachine;

        private void OnEnable() => 
            _stateMachine.Enter<BootStrapState>();
    }
}