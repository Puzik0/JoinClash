using UnityEngine;

namespace Model.Transformables
{
	public abstract class Transformable
	{
		private ITransformRules _rules = new ITransformRules.Default();
		
		protected Transformable(Vector3 position, Quaternion rotation)
		{
			Move(position);
			Rotate(rotation);
		}

		public Vector3 Position => _rules.Position;
		public Quaternion Rotation => _rules.Rotation;
		
		public Vector3 Forward => Rotation * Vector3.forward;

		public void BindRules(ITransformRules rules)
		{
			_rules = rules;
		}
		
		public void Move(Vector3 newPosition)
		{
			_rules.Move(newPosition);
		}

		public void Rotate(Quaternion rotation)
		{
			_rules.Rotate(rotation);
		}

		public void LookAt(Vector3 target)
		{
			_rules.LookAt(Position, target);
		}
	}
}