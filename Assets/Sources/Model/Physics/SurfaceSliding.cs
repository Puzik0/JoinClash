using Model.Messaging;
using UnityEngine;

namespace Model.Physics
{
	public class SurfaceSliding : ICollidable
	{
		private readonly string _groundTag;
		private Vector3 _surfaceNormal;

		public SurfaceSliding(string groundTag)
		{
			_groundTag = groundTag;
		}

		public Vector3 DirectionAlongSurface(Vector3 originalDirection)
		{
			return Vector3.ProjectOnPlane(originalDirection, _surfaceNormal);
		}

		public void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag(_groundTag))
				_surfaceNormal = collision.contacts[0].normal;
		}

		public void OnCollisionStay(Collision collision)
		{
		}

		public void OnCollisionExit(Collision collision)
		{
		}
	}
}