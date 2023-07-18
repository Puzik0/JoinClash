using GameStates.Base;
using UnityEngine;

namespace GameStates.States
{
    public class PauseState : IGameState
    {
        private const float PauseTimeScale = 0.0f;
        private float _timeScale;
        public void Enter()
        {
            _timeScale = Time.time;
            Time.timeScale = PauseTimeScale;
        }

        public void Exit()
        {
            Time.timeScale = _timeScale;
        }


    }
}