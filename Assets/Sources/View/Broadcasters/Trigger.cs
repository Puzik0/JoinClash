using System;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	public class Trigger : MonoBehaviour
	{
		private Type _origin;
		private Type _checked;
		private object _model;
		
		private Action<object> _handler;

		public GameObject Between<TOrigin, TChecked>(TOrigin model) => 
			Between<TOrigin, TChecked>(model, null);

		public GameObject Between<TOrigin, TChecked>(TOrigin model, Action<TChecked> handler)
		{
			_handler = obj => handler?.Invoke((TChecked)obj);
			_model = model;

			_origin = typeof(TOrigin);
			_checked = typeof(TChecked);

			return gameObject;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Trigger otherTrigger) == false)
				return;

			if (_checked == otherTrigger._origin)
				_handler?.Invoke(otherTrigger._model);
		}
	}
}