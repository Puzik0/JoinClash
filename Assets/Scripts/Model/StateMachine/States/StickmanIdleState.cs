using Model.StateMachine.States.Groups;
using Model.Stickmen;
using UnityEngine;

namespace Model.StateMachine.States
{
	public class StickmanIdleState : StickmanMoveStatesGroup
	{
		public StickmanIdleState(Animator animator, StickmanMovement movement, int animationHash)
			: base(animator, movement, animationHash) { }
	}
}