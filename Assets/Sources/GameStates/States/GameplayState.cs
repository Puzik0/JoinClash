using GameStates.Base;
using UnityEngine;
namespace GameStates.States
{
    public class GameplayState : IGameState
    {
        private const float PauseTimeScale = 1.0f;
        private float _timeScale;
        void IGameState.Enter()
        {
            _timeScale = Time.timeScale;
            Time.timeScale = PauseTimeScale;
        }

        void IGameState.Exit()
        {
            Time.timeScale = _timeScale;
        }
    }
}