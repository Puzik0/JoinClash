using UnityEngine;

namespace Model.StateMachine.States
{
	public class StickmanDeathState : StickmanState
	{
		private readonly AudioSource _audioSource;
		private readonly AudioClip _deathSound;

        public StickmanDeathState(AudioSource audioSource, AudioClip deathSound, int animationHash) : base(animationHash)
        {
            _audioSource = audioSource;
            _deathSound = deathSound;
        }

        public override void Enter(Animator animator, StickmanStateMachine stateMachine)
        {
            base.Enter(animator, stateMachine);
            _audioSource.PlayOneShot(_deathSound);
        }
    }
}