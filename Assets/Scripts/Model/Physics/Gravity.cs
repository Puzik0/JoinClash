using UnityEngine;

namespace Model.Physics
{
	public class Gravity
	{
		private readonly Transformable _transformable;
		
		public Gravity(Transformable transformable)
		{
			_transformable = transformable;
		}

		public void PhysicsTick(Vector3 gravityAffectedPosition)
		{
			_transformable.Move(gravityAffectedPosition);
		}
	}
}