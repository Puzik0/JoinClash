using UnityEngine;

namespace Model.StateMachine
{
	public static class StickmanAnimatorParameters
	{
		public static readonly int Idle = Animator.StringToHash("Idle");
		public static readonly int IsRunning = Animator.StringToHash("IsRunning");
		public static readonly int Move = Animator.StringToHash("Move");
	}
}