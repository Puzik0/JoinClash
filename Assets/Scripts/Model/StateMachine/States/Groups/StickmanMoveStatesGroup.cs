using Model.Stickmen;
using UnityEngine;

namespace Model.StateMachine.States.Groups
{
	public class StickmanMoveStatesGroup : StickmanState
	{
		private const float AccelerationToRun = 1.0f;
		private readonly StickmanMovement _movement;

		public StickmanMoveStatesGroup(Animator animator, StickmanMovement movement, int animationHash)
										: base(animator, animationHash)
		{
			_movement = movement;
		}

		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			if (_movement.Acceleration <= AccelerationToRun)
				stateMachine.Enter<StickmanIdleState>();
			else
				stateMachine.Enter<StickmanRunState>();
		}
	}
}