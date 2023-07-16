using Model;
using Model.Physics;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	[RequireComponent(typeof(Rigidbody))]
	public class GravityBroadcaster : MonoBehaviour
	{
		private Rigidbody _attachedBody;
		private Transformable _model;
		private Gravity _gravity;
		
		public void Initialize(Transformable model)
		{
			_attachedBody = GetComponent<Rigidbody>();
			_model = model;
			_gravity = new Gravity(model);
		}

		private void FixedUpdate()
		{
			Vector3 gravityAffectedPosition = new Vector3()
			{
				x = _model.Position.x,
				y = _attachedBody.position.y,
				z = _model.Position.z
			};

			_gravity.PhysicsTick(gravityAffectedPosition);
		}
	}
}