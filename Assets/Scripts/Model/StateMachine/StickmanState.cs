using UnityEngine;

namespace Model.StateMachine
{
	public abstract class StickmanState
	{
		private readonly Animator _animator;
		private readonly int _animationHash;

		protected StickmanState(Animator animator, int animationHash)
		{
			_animationHash = animationHash;
			_animator = animator;
		}

		public virtual void Enter(StickmanStateMachine stateMachine)
		{
			_animator.SetBool(_animationHash, true);
		}

		public virtual void Exit(StickmanStateMachine stateMachine)
		{
			_animator.SetBool(_animationHash, false);
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
			public None() : base(null, 0)
			{
			}

			public override void Enter(StickmanStateMachine stateMachine)
			{
			}

			public override void Exit(StickmanStateMachine stateMachine)
			{
			}
		}
	}
}