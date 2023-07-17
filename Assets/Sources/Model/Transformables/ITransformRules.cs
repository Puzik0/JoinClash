using UnityEngine;

namespace Model.Transformables
{
	public interface ITransformRules
	{
		void Move(Vector3 position);
		void Rotate(Quaternion rotation);

		void LookAt(Vector3 from, Vector3 target);

		Vector3 Position { get; }
		
		Quaternion Rotation { get; }
		
		public class Default : ITransformRules
		{
			public Vector3 Position { get; private set; }
			public Quaternion Rotation { get; private set; }

			public void Move(Vector3 position)
			{
				Position = position;
			}

			public void Rotate(Quaternion rotation)
			{
				Rotation = rotation;
			}

			public void LookAt(Vector3 from, Vector3 target)
			{
				Rotation = Quaternion.LookRotation(target - from);
			}
		}
	}
}