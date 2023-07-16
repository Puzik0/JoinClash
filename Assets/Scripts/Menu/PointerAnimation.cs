using DG.Tweening;
using UnityEngine;

namespace Menu
{
	public class PointerAnimation : MonoBehaviour
	{
		[SerializeField] private float _duration;
		[SerializeField] private Ease _movementCurve;
		
		[Header("Points")]
		[SerializeField] private Transform _startPoint;
		[SerializeField] private Transform _endPoint;

		private Tween _animation;

		private void OnEnable()
		{
			transform.position = _startPoint.position;

			_animation = transform
				.DOMove(_endPoint.position, _duration)
				.SetEase(_movementCurve)
				.SetLoops(-1, LoopType.Yoyo);
		}

		private void OnDisable() => 
			_animation?.Kill();
	}
}