using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input.Touches
{
	public class InputTouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private Coroutine _holdingRoutine;
		private Coroutine _releasedRoutine;
		
		public event Action<Touch> Begun;
		public event Action<Touch> Holding;
		public event Action<Touch> Ended;
		public event Action<Touch> Released;

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_releasedRoutine != null)
				StopCoroutine(_releasedRoutine);
			
			Begun?.Invoke(new Touch());
			_holdingRoutine = StartCoroutine(ProcessHoldingInput());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Ended?.Invoke(new Touch());
			StopCoroutine(_holdingRoutine);

			_releasedRoutine = StartCoroutine(ProcessReleasedInput());
		}

		private IEnumerator ProcessHoldingInput()
		{
			while (true)
			{
				Holding?.Invoke(new Touch());
				
				yield return null;
			}
		}
		
		private IEnumerator ProcessReleasedInput()
		{
			while (true)
			{
				Released?.Invoke(new Touch());
				
				yield return null;
			}
		}
	}
}