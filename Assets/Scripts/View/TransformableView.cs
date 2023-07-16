using Model;
using UnityEngine;

namespace Sources.View
{
	public class TransformableView : MonoBehaviour
	{
		private Transformable _model;

		public GameObject Initialize(Transformable model)
		{
			_model = model;

			return gameObject;
		}

		private void LateUpdate()
		{
			transform.position = _model.Position;
			transform.rotation = _model.Rotation;
		}
	}
}