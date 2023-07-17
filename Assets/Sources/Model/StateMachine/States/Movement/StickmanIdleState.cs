using Model.StateMachine;
using Model.Stickmen;

namespace Model.Sources.Model.StateMachine.States.Movement
{
	public class StickmanIdleState : StickmanMoveStatesGroup
	{
		public StickmanIdleState(StickmanMovement movement, int animationHash)
			: base(movement, animationHash) { }

		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			base.CheckTransitions(stateMachine);
			
			if (IsRunning)
				stateMachine.Enter<StickmanRunState>();
		}
	}
}