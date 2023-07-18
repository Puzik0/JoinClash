using GameStates.Base;
using GameStates.States;
using Input.Touches;
using StaticContext;
using UnityEngine;
using Touch = Input.Touches.Touch;

namespace Menu
{
	public class GameStartListener : MonoBehaviour
	{
		[SerializeField] private InputTouchPanel _startGamePanel;

		private void OnEnable() => 
			_startGamePanel.Begun += EnterGameplayState;

		private void OnDisable() => 
			_startGamePanel.Begun -= EnterGameplayState;

		private void EnterGameplayState(Touch touch) => 
			Instance<IGameStateMachine>
				.Value
				.Enter<GameplayStartState>();
	}
}