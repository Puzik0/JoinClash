using Model;
using UnityEngine;

namespace Sources.View
{
	public class TransformableView : MonoBehaviour
	{
		private Transformable _model;

		public void Initialize(Transformable model)
		{
			_model = model;
		}

		private void LateUpdate()
		{
			transform.position = _model.Position;
			transform.rotation = _model.Rotation;
		}
	}
}