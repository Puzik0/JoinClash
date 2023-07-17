using Model.Messaging;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	public class CollisionBroadcaster : MonoBehaviour
	{
		private ICollidable _model;

		public GameObject Initialize(ICollidable model)
		{
			_model = model;
			return gameObject;
		}

		private void OnCollisionEnter(Collision other)
		{
			_model.OnCollisionEnter(other);	
		}

		private void OnCollisionStay(Collision other)
		{
			_model.OnCollisionStay(other);
		}

		private void OnCollisionExit(Collision other)
		{
			_model.OnCollisionExit(other);
		}
	}
}