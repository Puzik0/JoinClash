using Model.Messaging;
using UnityEngine;

namespace Model.Physics
{
	public class SurfaceSliding : ICollidable
	{
		private Vector3 _surfaceNormal;

		public Vector3 DirectionAlongSurface(Vector3 originalDirection)
		{
			return Vector3.ProjectOnPlane(originalDirection, _surfaceNormal);
		}
		
		public void OnCollisionEnter(Collision collision)
		{
			_surfaceNormal = collision.contacts[0].normal;
		}

		public void OnCollisionStay(Collision collision) { }

		public void OnCollisionExit(Collision collision) { }
	}
}