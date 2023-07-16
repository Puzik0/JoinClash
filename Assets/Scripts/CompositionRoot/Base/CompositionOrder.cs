using System;
using UnityEngine;

namespace Sources.CompositeRoot.Base
{
	public class CompositionOrder : MonoBehaviour
	{
		[SerializeField] private CompositionRoot[] _order = Array.Empty<CompositionRoot>();

		private void OnValidate()
		{
			foreach (CompositionRoot compositionRoot in _order)
				if (compositionRoot != null)
					compositionRoot.enabled = false;
		}

		private void Awake()
		{
			foreach (CompositionRoot compositionRoot in _order)
			{
				compositionRoot.Compose();
				compositionRoot.enabled = true;
			}
		}
	}
}