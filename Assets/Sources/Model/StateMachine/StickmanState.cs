using UnityEngine;

namespace Model.StateMachine
{
	public abstract class StickmanState
	{
		private readonly int _animationHash;

		protected StickmanState(int animationHash)
		{
			_animationHash = animationHash;
		}

		public virtual void Enter(Animator animator, StickmanStateMachine stateMachine)
		{
			animator.SetBool(_animationHash, true);
		}

		public virtual void Exit(Animator animator, StickmanStateMachine stateMachine)
		{
			animator.SetBool(_animationHash, false);
		}

		public virtual void Tick(float deltaTime, StickmanStateMachine stateMachine)
		{
			CheckTransitions(stateMachine);
		}

		protected virtual void CheckTransitions(StickmanStateMachine stateMachine)
		{

		}

		public class None : StickmanState
		{
			public None() : base(0)
			{
			}

			public override void Enter(Animator animator, StickmanStateMachine stateMachine)
			{
			}

			public override void Exit(Animator animator, StickmanStateMachine stateMachine)
			{
			}
		}
	}
}