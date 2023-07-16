using UnityEngine;

namespace Model
{
	public abstract class Transformable
	{
		protected Transformable(Vector3 position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
		}

		public Vector3 Position { get; private set; }
		public Quaternion Rotation { get; private set; }

		public Vector3 Forward => Rotation * Vector3.forward;

		public void Move(Vector3 newPosition)
		{
			Position = newPosition;
		}
	}
}