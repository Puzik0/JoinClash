using UnityEngine;

namespace Model.StateMachine
{
	public static class StickmanAnimatorParameters
	{
		public static readonly int Idle = Animator.StringToHash("Idle");
		public static readonly int IsRunning = Animator.StringToHash("IsRunning");
		public static readonly int Charge = Animator.StringToHash("IsCharging");
		public static readonly int IsPunching = Animator.StringToHash("IsPunching");
		public static readonly int IsDead = Animator.StringToHash("IsDead");
	}
}