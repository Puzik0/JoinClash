using Model.Transformables;
using Sources.View.Extensions;
using UnityEngine;

namespace Sources.View
{
	public class PhysicsTransformableView : MonoBehaviour, ITransformRules
	{
		private Transformable _model;
		private Rigidbody _rigidbody;

		public GameObject Initialize(Transformable model)
		{
			_rigidbody = gameObject.RequireComponent<Rigidbody>();
			_model = model;
			_model.BindRules(this);
			
			return gameObject;
		}

		public void Move(Vector3 position)
		{
			_rigidbody.MovePosition(position);
		}

		public void Rotate(Quaternion rotation)
		{
			_rigidbody.MoveRotation(rotation);
		}

		public void LookAt(Vector3 from, Vector3 target)
		{
			_rigidbody.transform.LookAt(target);
		}

		public Vector3 Position => _rigidbody.position;

		public Quaternion Rotation => _rigidbody.rotation;
	}
}