using UnityEditor.Animations;
using UnityEngine;

namespace Sources.CompositeRoot.Extensions
{
	public static class AnimatorExtensions
	{
		public static GameObject BindController(this Animator animator, RuntimeAnimatorController controller)
		{
			animator.runtimeAnimatorController = controller;
			return animator.gameObject;
		}
	}
}