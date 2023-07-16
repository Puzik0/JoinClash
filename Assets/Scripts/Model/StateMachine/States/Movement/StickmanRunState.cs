using Model.StateMachine;
using Model.Stickmen;

namespace Model.Sources.Model.StateMachine.States.Movement
{
	public class StickmanRunState : StickmanMoveStatesGroup
	{
		public StickmanRunState(StickmanMovement movement, int animationHash) 
			: base(movement, animationHash) { }

		protected override void CheckTransitions(StickmanStateMachine stateMachine)
		{
			base.CheckTransitions(stateMachine);
			
			if (IsRunning == false)
				stateMachine.Enter<StickmanIdleState>();
		}
	}
}