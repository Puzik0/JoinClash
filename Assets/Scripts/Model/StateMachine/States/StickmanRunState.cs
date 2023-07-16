using Model.StateMachine.States.Groups;
using Model.Stickmen;
using UnityEngine;

namespace Model.StateMachine.States
{
	public class StickmanRunState : StickmanMoveStatesGroup
	{
		public StickmanRunState(Animator animator, StickmanMovement movement, int animationHash) 
			: base(animator, movement, animationHash) { }
	}
}