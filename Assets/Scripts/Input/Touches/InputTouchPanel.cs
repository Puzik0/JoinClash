using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input.Touches
{
	public class InputTouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private Coroutine _holdingRoutine;
		
		public event Action<Touch> Begun;
		public event Action<Touch> Holding;
		public event Action<Touch> Ended;
		
		public void OnPointerDown(PointerEventData eventData)
		{
			Begun?.Invoke(new Touch());
			_holdingRoutine = StartCoroutine(ProcessHoldingInput());
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Ended?.Invoke(new Touch());
			StopCoroutine(_holdingRoutine);
		}

		private IEnumerator ProcessHoldingInput()
		{
			while (true)
			{
				Holding?.Invoke(new Touch());
				
				yield return null;
			}
		}
	}
}